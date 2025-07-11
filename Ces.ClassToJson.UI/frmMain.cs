﻿using System.Diagnostics;

namespace Ces.ClassToJson.UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private Ces.ClassToJson.ClassToJson _cls;
        private string _assembplyPath;
        private string _outputPath;
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private List<string> _selectedNodes = new();
        private bool _expandAll;

        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            if (!_expandAll)
            {
                tvTypes.ExpandAll();
                _expandAll = true;
            }
            else
            {
                tvTypes.CollapseAll();
                _expandAll = false;
            }
        }

        private async void btnConvertToJson_Click(object sender, EventArgs e)
        {
            try
            {
                btnConvertToJson.Enabled = false;
                _cancellationTokenSource = new CancellationTokenSource();
                CreateInstance();

                if (chkAllObjects.Checked)
                    await ConvertAllAssembly();
                else
                    await ConvertSelectedNodes();

                txtJsonResult.Text = System.IO.File.ReadAllText(_cls._option.OutpuPath);
            }
            catch (Exception ex)
            {
                _cancellationTokenSource.Cancel();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnConvertToJson.Enabled = true;
            }

        }

        private async Task GetAssemblyObjectsClassAsync()
        {
            var classList = new List<string>();
            var types = new List<Type>();

            try
            {
                types = await _cls.GetObjectsAsync(_cancellationTokenSource.Token);
            }
            catch (Exception ex)
            {
                _cancellationTokenSource.Cancel();
                MessageBox.Show(ex.Message);
            }

            if (tvTypes.Nodes.Count > 0)
                tvTypes.Nodes.Clear();

            foreach (var type in types)
                if (!classList.Contains(type.FullName))
                    classList.Add(type.FullName);

            foreach (string type in classList)
            {
                var typeNames = type.Split('.');
                var currentNodes = tvTypes.Nodes;

                //This loop generated by ChatGPt
                foreach (string name in typeNames)
                {
                    var node = currentNodes.Cast<TreeNode>().FirstOrDefault(x => x.Text == name);

                    if (node == null)
                    {
                        node = new TreeNode(name);
                        currentNodes.Add(node);
                    }

                    // Move to next level
                    currentNodes = node.Nodes;
                }
            }
        }

        private async Task ConvertSelectedNodes()
        {
            _selectedNodes.Clear();
            GetSelectedNodes();

            if (_selectedNodes == null || _selectedNodes.Count == 0)
            {
                MessageBox.Show("Select one node at least");
                return;
            }

            await _cls.ConvertToJsonAsync(_selectedNodes, _cancellationTokenSource.Token);
        }

        private async Task ConvertAllAssembly()
        {
            await _cls.ConvertToJsonAsync(_cancellationTokenSource.Token);
        }

        private void GetSelectedNodes(TreeNode node = null)
        {
            foreach (TreeNode treeNode in node?.Nodes ?? tvTypes.Nodes)
            {
                if (treeNode.Checked)
                    _selectedNodes.Add(treeNode.FullPath.Replace(@"\", "."));

                if (treeNode.Nodes.Count > 0)
                    GetSelectedNodes(treeNode);
            }
        }

        private async void btnSelectFile_Click(object sender, EventArgs e)
        {
            btnConvertToJson.Enabled = false;
            var open = new OpenFileDialog();
            open.Multiselect = false;
            open.RestoreDirectory = true;
            open.Title = "Choose assembly";
            open.Filter = "DTO Models(*.dll)|*.dll";

            try
            {
                if (open.ShowDialog(this) == DialogResult.OK)
                {
                    _assembplyPath = open.FileName;
                    CreateInstance();
                    await GetAssemblyObjectsClassAsync();
                }
            }
            catch (Exception ex)
            {
                _cancellationTokenSource.Cancel();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnConvertToJson.Enabled = true;
            }
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            ClearSelectedNodes();
        }

        private void ClearSelectedNodes(TreeNode node = null)
        {
            foreach (TreeNode treeNode in node?.Nodes ?? tvTypes.Nodes)
            {
                if (treeNode.Checked)
                    treeNode.Checked = false;

                if (treeNode.Nodes.Count > 0)
                    ClearSelectedNodes(treeNode);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var save = new SaveFileDialog();
            save.AddExtension = true;
            save.Filter = "Json|*.json";
            save.DefaultExt = ".json";
            save.FileName = "ConvertToJson" + DateTime.Now.ToString(" _ yyyy-MM-dd _ HH-mm-ss");

            try
            {
                if (save.ShowDialog(this) == DialogResult.OK)
                {
                    _outputPath = save.FileName;
                    CreateInstance();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkUseSamePath_CheckedChanged(object sender, EventArgs e)
        {
            btnOutputPath.Enabled = !chkUseSamePath.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }

        private void CreateInstance()
        {
            try
            {
                var option = new Ces.ClassToJson.ClassToJsonOption
                {
                    AssemblyPath = _assembplyPath,
                    OutpuPath = _outputPath,
                    UseAssemblyPath = chkUseSamePath.Checked,
                    OverWrite = chkOverwrite.Checked,
                    RemoveNamespaceDelimiter = chkRemoveNamespaceDelimiter.Checked,
                    NamespaceDelimiter = string.IsNullOrEmpty(txtNamespaceDelimiter.Text) ? null : char.Parse(txtNamespaceDelimiter.Text),
                    AddDataType = chkAddDataType.Checked,
                };

                _cls = new Ces.ClassToJson.ClassToJson(option);

                lblAssmeblyPath.Text = "Assembly : " + _cls._option.AssemblyPath;
                lblOutputPath.Text = "Output : " + _cls._option.OutpuPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblAssmeblyPath_Click(object sender, EventArgs e)
        {
            OpenDirectory(_cls._option.AssemblyPath);
        }

        private void lblOutputPath_Click(object sender, EventArgs e)
        {
            OpenDirectory(_cls._option.OutpuPath);
        }

        private void OpenDirectory(string path)
        {
            try
            {
                if (_cls != null)
                    Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(path));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tvTypes_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            CheckChildNodes(e.Node);
        }

        private void CheckChildNodes(TreeNode node)
        {
            if (node.Checked && node.GetNodeCount(false) > 0)
                foreach (TreeNode item in node.Nodes)
                {
                    item.Checked = true;

                    if (node.GetNodeCount(false) > 0)
                        CheckChildNodes(item);
                }
        }

        private void chkRemoveNamespaceDelimiter_CheckedChanged(object sender, EventArgs e)
        {
            txtNamespaceDelimiter.Enabled = chkRemoveNamespaceDelimiter.Checked;
        }      
    }
}
