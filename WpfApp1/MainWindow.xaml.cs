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
using System.Runtime;
using System.Globalization;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            FirstFunc();

        }


        public void FirstFunc()
        {

            //float startingangle = HexToFloat("40C8C5FD");
            float startingangle = (float)6.274168491;


            //float sens = HexToFloat("3A55834D");
            float sens = (float)0.00081448705168441; //seems to be equivalent (this is the mouse delta for sens 2.1 btw)
            //Console.WriteLine(FloatToHex(sens) + "sanity check");


            //okay first let's test adding it to itself 100 times
            float h = startingangle;
            for (int i = 0; i < 100; i++)
            {
                h = (float)(h - sens); //it is NECESSARY to cast the result to float again, to match in-game behaviour
            }

            //h = startingangle - h;
            Console.WriteLine(FloatToHex(h) + " test val");
            //this prints 40C62ACD

            //then let's test multiplying it by 100
            float y = (float)(startingangle - (float)(sens * 100));
            Console.WriteLine(FloatToHex(y) + " test val 2");
            //this prints 40C62AC3



            //if we call MoveMouseVar(0.00081448705168441, 100) (ie 100x 1-pixel movements)
            //then our ingame value becomes 40C62ACD

            //if we call MoveMouseVar(0.081448696553707, 1) (ie big 100p swipe in one movement)
            //then our ingame value becomes 40C62AC3

            //this is drift from moving at diff speeds! that's bad! real bad! (at least it matches our math too tho)
            //this isn't an artifact of MoveMouseVar being buggy, you can get this behaviour by just moving your 
            //mouse around in-game and trying to reach an exact value that you reached before; 
            //the more you move the mouse, the further away from it you'll be able to get.



        }




        public static float HexToFloat(string hexString)
        {

            Int32 IntRep = Int32.Parse(hexString, NumberStyles.AllowHexSpecifier);
            float myFloat = BitConverter.ToSingle(BitConverter.GetBytes(IntRep), 0);
            return myFloat;

        }

        public static string FloatToHex(float myFloat)
        {

            var bytes = BitConverter.GetBytes(myFloat);
            var i = BitConverter.ToInt32(bytes, 0);
            return i.ToString("X8");

        }

    }
}
