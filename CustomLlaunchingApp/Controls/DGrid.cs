using CustomLlaunchingApp.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CustomLlaunchingApp
{
    internal class DGrid : Grid
    {
        public Action<Ppoint , (MouseButtonState , MouseButton , UIElement ui )> MouseAction = null;

        Ppoint mosue_pos = new Ppoint();
        MouseButtonState ButtonState = MouseButtonState.Released;
        MouseButton mouseButton;
        UIElement ui_hover;
        public DGrid()
        {
            this.Background = new SolidColorBrush(Color.FromArgb(1,0,0,0));
             
            
            this.MouseMove += (o, e) =>
            {
                mosue_pos = new Ppoint((int)e.GetPosition(this).X, (int)e.GetPosition(this).Y);
                MouseActions();
            };
            this.PreviewMouseDown += (o, e) =>
            {
                mouseButton = e.ChangedButton;
                ButtonState = e.ButtonState;
                ui_hover = e.OriginalSource as UIElement;
                MouseActions();
            };
            this.PreviewMouseUp += (o, e) =>
            {
                ///mouseButton = e.ChangedButton;
                ButtonState = e.ButtonState;
                MouseActions();
            };

        }
        void MouseActions()
        {
            if (MouseAction != null)
                MouseAction(mosue_pos, (ButtonState, mouseButton , ui_hover));
        }
    }
}
