using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace TriangleTestCase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<TestResult> results = new ObservableCollection<TestResult>();
        private int line1_max;
        private int line1_min;
        private int line2_max;
        private int line2_min;
        private int line3_max;
        private int line3_min;

        private Line line1;
        private Line line2;
        private Line line3;

        private int count;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Test_Click(object sender, RoutedEventArgs e)
        {
            if (CheckMaxMin())
            {
                count = 1;
                results.Clear();
                GenerateData();

                if (comboBox_TestType.SelectedIndex == 0)
                {
                    CheckBoundaryValue();
                }
                else if (comboBox_TestType.SelectedIndex == 1)
                {
                    CheckRobustness();
                }
                else if (comboBox_TestType.SelectedIndex == 2)
                {
                    CheckWorst();
                }
                else if (comboBox_TestType.SelectedIndex == 3)
                {
                    CheckRobustWorst();
                }
            }
        }

        private bool CheckMaxMin()
        {
            if (!int.TryParse(textBox_line1_min.Text, out line1_min))
            {
                MessageBox.Show("边1的最小值输入不正确");
                return false;
            }

            if (!int.TryParse(textBox_line1_max.Text, out line1_max))
            {
                MessageBox.Show("边1的最大值输入不正确");
                return false;
            }

            if (!int.TryParse(textBox_line2_min.Text, out line2_min))
            {
                MessageBox.Show("边2的最小值输入不正确");
                return false;
            }

            if (!int.TryParse(textBox_line2_max.Text, out line2_max))
            {
                MessageBox.Show("边2的最大值输入不正确");
                return false;
            }

            if (!int.TryParse(textBox_line3_min.Text, out line3_min))
            {
                MessageBox.Show("边3的最小值输入不正确");
                return false;
            }

            if (!int.TryParse(textBox_line3_max.Text, out line3_max))
            {
                MessageBox.Show("边3的最大值输入不正确");
                return false;
            }

            if (line1_min <= 0)
            {
                MessageBox.Show("边1的最小值必须为正数");
                return false;
            }

            if (line2_min <= 0)
            {
                MessageBox.Show("边2的最小值必须为正数");
                return false;
            }

            if (line2_min <= 0)
            {
                MessageBox.Show("边3的最小值必须为正数");
                return false;
            }

            if (line1_min >= line1_max || line2_min >= line2_max || line3_min >= line3_max)
            {
                MessageBox.Show("边的最大值必须大于最小值");
                return false;
            }

            return true;
        }

        private void GenerateData()
        {
            line1 = new Line(line1_min, line1_max);
            line2 = new Line(line2_min, line2_max);
            line3 = new Line(line3_min, line3_max);
        }

        private void CheckBoundaryValue()
        {
            CheckTriangle(line1.Min,        line2.Middle, line3.Middle);
            CheckTriangle(line1.MinGreater, line2.Middle, line3.Middle);
            CheckTriangle(line1.MaxLess,    line2.Middle, line3.Middle);
            CheckTriangle(line1.Max,        line2.Middle, line3.Middle);

            CheckTriangle(line1.Middle, line2.Min,        line3.Middle);
            CheckTriangle(line1.Middle, line2.MinGreater, line3.Middle);
            CheckTriangle(line1.Middle, line2.MaxLess,    line3.Middle);
            CheckTriangle(line1.Middle, line2.Max,        line3.Middle);

            CheckTriangle(line1.Middle, line2.Middle, line3.Min);
            CheckTriangle(line1.Middle, line2.Middle, line3.MinGreater);
            CheckTriangle(line1.Middle, line2.Middle, line3.MaxLess);   
            CheckTriangle(line1.Middle, line2.Middle, line3.Max);       

            CheckTriangle(line1.Middle, line2.Middle, line3.Middle);                         
        }

        private void CheckRobustness()
        {
            CheckBoundaryValue();

            CheckTriangle(line1.MinLess,    line2.Middle, line3.Middle);
            CheckTriangle(line1.MaxGreater, line2.Middle, line3.Middle);

            CheckTriangle(line1.Middle, line2.MinLess,    line3.Middle);
            CheckTriangle(line1.Middle, line2.MaxGreater, line3.Middle);

            CheckTriangle(line1.Middle, line2.Middle, line1.MinLess);
            CheckTriangle(line1.Middle, line2.Middle, line1.MaxGreater);
        }

        private void CheckWorst()
        {
            int[] line1Arr = { line1.Min, line1.MinGreater, line1.Middle, line1.MaxLess, line1.Max };
            int[] line2Arr = { line2.Min, line2.MinGreater, line2.Middle, line2.MaxLess, line2.Max };
            int[] line3Arr = { line3.Min, line3.MinGreater, line3.Middle, line3.MaxLess, line3.Max };

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        CheckTriangle(line1Arr[i], line2Arr[j], line3Arr[k]);
                    }
                }
            }
        }

        private void CheckRobustWorst()
        {
            int[] line1Arr = { line1.MinLess, line1.Min, line1.MinGreater, line1.Middle, line1.MaxLess, line1.Max, line1.MaxGreater };
            int[] line2Arr = { line2.MinLess, line2.Min, line2.MinGreater, line2.Middle, line2.MaxLess, line2.Max, line2.MaxGreater };
            int[] line3Arr = { line3.MinLess, line3.Min, line3.MinGreater, line3.Middle, line3.MaxLess, line3.Max, line3.MaxGreater };

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    for (int k = 0; k < 7; k++)
                    {
                        CheckTriangle(line1Arr[i], line2Arr[j], line3Arr[k]);
                    }
                }
            }
        }        
        
        private void CheckTriangle(int line1, int line2, int line3)
        {
            bool result;
            string info;

            if ((line1 + line2 <= line3) || (line1 + line3 <= line2) || (line2 + line3 <= line1))
            {
                result = false;
                info = "三条边不能构成三角形！";
            }
            else if (line1 == line2 && line2 == line3)
            {
                result = true;
                info = "三条边构成等边三角形！";
            }
            else if (line1 == line2 || line2 == line3 || line1 == line3)
            {
                result = true;
                info = "三条边能构成等腰三角形！";
            }
            else
            {
                result = true;
                info = "三条边能构成非等边三角形！";
            }

            TestResult tr = new TestResult(count, line1.ToString(), line2.ToString(), line3.ToString(), result.ToString(), info.ToString());
            results.Add(tr);
            count++;
            dataGrid_TestResult.ItemsSource = results;
        }
    }
}
