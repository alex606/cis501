using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControlSystem
{
    class ListDialogDemo
    {
        Console console;
        public ListDialogDemo(Console console)
        {
            this.console = console;
        }
        public void ListDemo()
        {
            console.ResetListDialog();  // resetting is not requred for the first time, but it is a good habbit

            // create object[] and call AppendListDialog(object[]).  Eacch entry of object[] is printed in a separate line
            // not that '\n' does not work
            object[] obj1 = { "this is the first line", "this is the second line" };
            console.AppendItemsToListDialog(obj1);
            console.ShowListDialog();   // now show the list dialog.

            // since AppendItemsToListDialog(obj) is declared as "AppendItemsToListDialog(params object[] obj)",
            // you can append each line by separated by ','
            console.AppendItemsToListDialog("this is the 3rd line", "and the 4th line follows");
            console.ShowListDialog();

           string[] obj2 = { "5th line", "6th line"}; // you can concatenate more objects
            // since string is a subclass of ojbect, you can pass string[] to AppendItemsToListDialog()
            console.AppendItemsToListDialog(obj2);
            console.ShowListDialog();

            console.ResetListDialog();  // delete all lines and start over

            console.AppendItemsToListDialog("Brand new line", "Hi Hello");
            console.ShowListDialog();

            console.DisplayListDialog(obj1);  // this calls ResetListDialog(), AppendItemsToListDialog(object[]), and ShowListDialog(); this order
        }
    }
}
