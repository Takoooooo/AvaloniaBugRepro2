using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Input;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;


namespace WpfApp2
{
    public class GridCellControl : Control
    {
        private bool _isMouseOver = false;
        private bool IsMouseOver
        {
            get => _isMouseOver;
            set
            {
                if (_isMouseOver == value) return;
                _isMouseOver = value;
                InvalidateVisual();
            }
        }

        public static T? FindParent<T>(IControl child) where T :class, IControl
        {

            //we've reached the end of the tree
            if (child.Parent == null) return null;

            //check if the parent matches the type we're looking for
            T parent = child.Parent as T;
            if (parent != null)
                return parent;
            else
                return FindParent<T>(child.Parent);
        }
        public EventHandler? Refresh;

        protected override void OnPointerEnter(PointerEventArgs e)
        {
            base.OnPointerEnter(e);
            IsMouseOver = true;
        }
        protected override void OnPointerLeave(PointerEventArgs e)
        {
            base.OnPointerLeave(e);
            IsMouseOver = false;
        }
        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e); 
            FindParent<ContentControl>(this).Content = new GridCellControl() { Width = 50, Height = 50 };
        }

        public override void Render(DrawingContext context)
        {
            base.Render(context);
            if (IsMouseOver)
            {
                context.DrawRectangle(Brushes.Red, null, new Rect(0, 0, 25, 25));
            }
            else
            {
                context.DrawRectangle(Brushes.Black, null, new Rect(0, 0, 25, 25));
            }
        }
    }
}
