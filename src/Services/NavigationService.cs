using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Controls;

namespace MotorsportManagerHelper.src.Services
{
    public class NavigationService 
    {
        readonly Frame frame;

        public Frame CurrentFrame { get => frame; }

        public NavigationService(Frame frame)
        {
            this.frame = frame;
        }

        public void GoBack() {
            frame.GoBack();
        }

        public void GoForward()
        {
            frame.GoForward();
        }

        public bool Navigate(Type source, object parameter = null)
        {
            var src = Activator.CreateInstance(source);
            return frame.Navigate(src, parameter);
        }

        public bool Navigate<T>(object parameter = null)
        {
            var src = typeof(T);
            return Navigate(src, parameter);
        }

        public bool Navigate(string pageName)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(x => x.Name.Equals(pageName));
            if (type == null) return false;

            var src = Activator.CreateInstance(type);
            return frame.Navigate(src);
        }
    }
}
