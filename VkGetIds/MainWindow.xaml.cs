using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace VkGetIds
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBox textBoxinput,textBoxOut;

        public MainWindow()
        {
            InitializeComponent();
            textBoxinput = textBoxForID;
            textBoxOut = textboxOutput;
          

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //textBox.Text = textBox.Text+String.Join("\n",VK.DoSomething())+"\n";
            List<string> links = textBoxinput.Text.Split('\n').ToList();
            VK vK = new VK();
            List<string> outputLinks = new List<string>();
            for(int i = 0;i< links.Count;i++)
            {
                outputLinks.Add(vK.getVkID(links[i]));
                textBoxOut.Text = $"{i}/{links.Count}";
            }
            textBoxOut.Text = String.Join("\n", outputLinks) + "\n";

        }
    }
}
