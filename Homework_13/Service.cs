using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Homework_13
{
    /// <summary>
    /// Сервисный класс для реализации функционала
    /// </summary>
    public static class Service
    {
        /// <summary>
        /// Событие, если проходит год
        /// </summary>
        public static event Action? OneYearLater;
        


        /// <summary>
        /// Пропускает год
        /// </summary>
        public static void SkipYear()
        {
            OneYearLater?.Invoke();
        }
        public static void ShowNotification(string message)
        {
            MessageBox.Show(message);
        }


    }
}
