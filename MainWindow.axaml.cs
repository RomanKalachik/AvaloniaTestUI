using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using System;

namespace TestUI {
    public class MainWindow : Window {


        public static readonly AvaloniaProperty<int> PropertyDeclaration =
     AvaloniaProperty.Register<MainWindow, int>("Angle", inherits: true);

        public MainWindow() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
            DataContext=this;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval=TimeSpan.FromMilliseconds(30);
            timer.Tick+=Timer_Tick;
            Angle=0;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            Angle+=1;
        }

        public int Angle {
            get { return (int)this.GetValue(PropertyDeclaration); }
            set { this.SetValue(PropertyDeclaration, value); }
        }
    }
}
