using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Drawing;

namespace MyControl
{
    class MyActionList : DesignerActionList
    {
        MyProgressBar ground;
        DesignerActionUIService designerActionUIService;
        // Конструктор
        public MyActionList(IComponent component): base(component)
        {
            // Зберегти посилання на компонент, який редагується
            ground = component as MyProgressBar;
            // Зберегти посилання на сервіс ActionList
            designerActionUIService =
            GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }
        // В діалог тега вынести 1 властивості та одну команду
        public bool Round
        {
            get { return this.ground.Round; }
            set
            {
                GetPropertyByName("Round").SetValue(ground, value);
                // Обновити діалог тега
                designerActionUIService.Refresh(ground);
            }
        }
       
        
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new
            DesignerActionItemCollection();
            // Додати дві группи
            items.Add(new DesignerActionHeaderItem("Властивості",
            "Properties"));
            // Додати властивості в категорію Properties
            items.Add(new DesignerActionPropertyItem("Round",
            "Заокруглення", "Properties",
            "Колір початку градієнтного заповнення"));
            // Додати статичний текст
            items.Add(new DesignerActionHeaderItem("Інформація", "Info"));
            string info = string.Format("Розмір {0}x{1}", ground.Width,
            ground.Height);
            items.Add(new DesignerActionTextItem(info, "Info"));
            return items;
        }
        // Повертає дескриптор властивостей за ім'ям
        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop = TypeDescriptor.GetProperties(ground)
            [propName];
            if (prop == null)
            {
                throw new ArgumentException("Властивысть не існує",
                propName);
            }
            return prop;
        }
    }
}
