using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NCalc;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace BisectionCalculator.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public class StepGrid
        {
            private double x0;
            private double x1;
            private double x2;
            private double fx2;

            public double X0
            {
                get { return x0; }
                set { x0 = value; }
            }

            public double X1
            {
                get { return x1; }
                set { x1 = value; }
            }

            public double X2
            {
                get { return x2; }
                set { x2 = value; }
            }

            public double FX2
            {
                get { return fx2; }
                set { fx2 = value; }
            }

            public StepGrid(double x0, double x1, double x2, double fx2)
            {
                this.x0 = x0;
                this.x1 = x1;
                this.x2 = x2;
                this.fx2 = fx2;
            }
        }


        private string function;
        private double a;
        private double b;
        private double eps;
        private ObservableCollection<StepGrid> steps = new ObservableCollection<StepGrid>();

        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            Steps = new ObservableCollection<StepGrid>();
            Operation = new RelayCommand<string>((arg) => FindRoot());
        }

        public string Function
        {
            get
            {
                return function;
            }
            set
            {
                function = value;
                RaisePropertyChanged(() => Function);
            }
        }

        public double A
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
                RaisePropertyChanged(() => A);
            }
        }

        public double B
        {
            get
            {
                return b;
            }
            set
            {
                b = value;
                RaisePropertyChanged(() => B);
            }
        }

        public double EPS
        {
            get
            {
                return eps;
            }
            set
            {
                eps = value;
                RaisePropertyChanged(() => EPS);
            }
        }

        public ObservableCollection<StepGrid> Steps
        {
            get
            {
                return steps;
            }
            set
            {
                steps = value;
                RaisePropertyChanged(() => Steps);
            }
        }

        double F(double x)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            string foo = myTI.ToTitleCase(Function);
            if (foo.Contains("X")) foo = foo.Replace("X", "[x]");
            if (foo.Contains("Ln")) foo = foo.Replace("Ln", "Log10");
            NCalc.Expression e = new NCalc.Expression(foo);
            e.Parameters["x"] = x;
            return (double)e.Evaluate();
        }

        public bool Val { get; set; }

    public ICommand Operation { get; private set; }

        double DoCalculation()
        {
            try
            {
                double a = A, b = B, EPS = this.EPS;
                Val = false;
                Steps.Clear();
                // метод выполняется до тех пор, пока корень, вычисленный на текущей итерации,
                // не будет отличаться от истинного не более, чем на величину погрешности
                while (System.Math.Abs(b - a) > EPS)
                {
                    // находим середину отрезка [ a; b ]
                    double c = (a + b) / 2.0;
                    Steps.Add(new StepGrid(a, b, c, F(c)));
                    // нужно понять, на каком подотрезке [ a; c ] или [ c; b ] лежит искомый корень
                    // знаки функций на концах отрезка должны быть различными

                    // если условие выполняется, то искомый корень лежит на отрезке [ a; c ]
                    if (F(a) * F(c) <= 0)
                    {
                        b = c;      // перестраиваем границы отрезка в формат [ a; b ]
                    }
                    // автоматически иначе искомый корень лежит на отрезке [ c; b ]
                    else
                    {
                        a = c;      // перестраиваем границы отрезка в формат [ a; b ]
                    }                    
                    RaisePropertyChanged(() => Steps);
                }

                // в качестве ответа возвращаем координату центра отрезка [ a; b ], на котором лежит искомый корень
                // найденное значение приближенного корня гарантировано отличается от истинного не более, чем на величину EPS
                return (a + b) / 2.0;
            }
            catch { Val = true; return 0;}
        }

        public void FindRoot()
        {
            DoCalculation();
            if (Val == true) MessageBox.Show("Enter valid values!");
            else MessageBox.Show("Root is: " + DoCalculation().ToString());
        }
    }
}