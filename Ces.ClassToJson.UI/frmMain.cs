namespace Ces.ClassToJson.UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private void btnReadObjects_Click(object sender, EventArgs e)
        {
            var option = new Ces.ClassToJson.ClassToJsonOption
            {
                AssemblyPath = @"C:\Users\Caspian\Desktop\Ces.Caspian\Ces.Caspian.Models\bin\Debug\net8.0\Ces.Caspian.Models.dll"
            };

            var cls = new Ces.ClassToJson.ClassToJson(option);
            var types = cls.CovertAsync(_cancellationTokenSource.Token);
        }
    }
}
