using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Intro.Libraries
{
    public class Binder
    {
        //
    }
    interface IControl
    {
        void Paint();
    }

    interface ITextBox : IControl
    {
        void SetText(string text);
    }

    interface IListBox : IControl
    {
        void SetItems(string[] items);
    }

    interface IComboBox : ITextBox, IListBox
    {

    }

    interface IDataBound
    {
        void Bind(Binder b);
    }

    public class EditBox : IControl, IDataBound
    {
        public EditBox() 
        {
            Console.WriteLine(" Initializing ...");
        }

        void IControl.Paint() {
            Console.WriteLine(" Painting ..."); 
        }

        void IDataBound.Bind(Binder b) {
            Console.WriteLine(" Binding...");
        }
    }
}
