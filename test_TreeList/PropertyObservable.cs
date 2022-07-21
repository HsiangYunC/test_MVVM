using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace PropertyObserve
{
    /// <summary>
    /// PropertyObservable
    /// </summary>
    public abstract class PropertyObservable : INotifyPropertyChanged
    {
        /// <summary>
        /// 因為避免event被序列化，所以才有這個private版本的
        /// </summary>
        private PropertyChangedEventHandler _propertyChanged;

        /// <summary>
        /// 目前執行緒的處理內容。
        /// </summary>
        //private SynchronizationContext _synchronizationContext;

        /// <summary>
        /// 初始化
        /// </summary>
        public PropertyObservable()
        {
        }

        /// <summary>
        /// 屬性變更時觸發的事件
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                if (_propertyChanged == null || !_propertyChanged.GetInvocationList().Contains(value))
                    _propertyChanged += value;
            }
            remove
            {
                _propertyChanged -= value;
            }
        }

        /// <summary>
        /// 是否要發送通知
        /// </summary>
        public static bool IsEnableNotify { get; set; } = true;

        /// <summary>
        /// This method is called by the Set accessor of each property.
        /// The CallerMemberName attribute that is applied to the optional propertyName
        /// parameter causes the property name of the caller to be substituted as an argument.
        /// </summary>
        /// <param name="propertyName">屬性名稱</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (!IsEnableNotify)
                return;

            if (_propertyChanged != null)
            {
                try
                {
                    // Application 是 WPF 才有的機制
                    // 如果主程式是 WinForm app，記得在開啟 main form 前呼叫下列 code:
                    // if (System.Windows.Application.Current == null)
                    // {
                    //     new System.Windows.Application();
                    // }

                    if (Application.Current != null)
                    {
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            try
                            {
                                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
                            }
                            catch (Exception e)
                            {
                                Debug.WriteLine(e.Message);
                            }
                        }));
                    }
                    else
                        _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
        }
    }
}
