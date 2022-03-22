using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
        public static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            //get parent item
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            //we've reached the end of the tree
            if (parentObject == null) return null;

            //check if the parent matches the type we're looking for
            T parent = parentObject as T;
            if (parent != null)
                return parent;
            else
                return FindParent<T>(parentObject);
        }
        public EventHandler? Refresh;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            FindParent<ContentPresenter>(this).Content = new GridCellControl() { Width = 50, Height = 50 };
        }
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            IsMouseOver = false;
        }
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            IsMouseOver = true;
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (IsMouseOver)
            {
                drawingContext.DrawRectangle(Brushes.Red, null, new Rect(0, 0, 25, 25));
            }
            else
            {
                drawingContext.DrawRectangle(Brushes.Black, null, new Rect(0, 0, 25, 25));
            }
        }

    }
}
