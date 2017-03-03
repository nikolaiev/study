using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.Design;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace MyControl
{
    class MyDesigner :ControlDesigner 
    {
        private DesignerActionListCollection actionLists;
        
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                // Якщо не побудований actionList
                if (actionLists == null)
                {
                    // Побудувати ActionList
                    actionLists = new DesignerActionListCollection();
                    // Додати смарт-тег
                    actionLists.Add(new MyActionList(this.Component));
                }
                return actionLists;
            }
        }
    }
}
