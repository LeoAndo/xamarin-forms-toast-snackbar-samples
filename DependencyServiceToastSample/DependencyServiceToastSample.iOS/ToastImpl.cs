using Foundation;
using DependencyServiceToastSample.iOS;
using UIKit;
using CoreGraphics;
using System;

[assembly: Xamarin.Forms.Dependency(typeof(ToastImpl))]
namespace DependencyServiceToastSample.iOS
{
    public class ToastImpl : IToast
    {
        public void Show(string message)
        {
            var toast = new Toast();
            toast.Show(UIApplication.SharedApplication.KeyWindow.RootViewController.View, message);
        }
    }

    class Toast
    {
        // Toast View
        UIView _view;
        // Toast message
        UILabel _label;
        // Toast size
        int _margin = 30;
        int _height = 40;
        int _width = 150;

        NSTimer _timer = null;

        public Toast()
        {
            // create Toast View
            _view = new UIView(new CGRect(0, 0, 0, 0))
            {
                BackgroundColor = UIColor.Black,
            };
            _view.Layer.CornerRadius = (nfloat)20.0;
            //  create Toast Label
            _label = new UILabel(new CGRect(0, 0, 0, 0))
            {
                TextAlignment = UITextAlignment.Center,
                TextColor = UIColor.White
            };
            _view.AddSubview(_label);

        }

        public void Show(UIView parent, string message)
        {
            // 既に表示中の場合は、処理を停止する
            if (_timer != null)
            {
                _timer.Invalidate();
                _view.RemoveFromSuperview(); // 親ビューから削除する
            }

            // アルファ値0.7で表示を開始する
            _view.Alpha = (nfloat)0.7;

            // 親Viewからトーストのサイズを調整する
            _view.Frame = new CGRect(
                (parent.Bounds.Width - _width) / 2,
                parent.Bounds.Height - _height - _margin,
                _width,
                _height);

            _label.Frame = new CGRect(0, 0, _width, _height);
            _label.Text = message; // ラベルの表示文字列を設定する

            parent.AddSubview(_view);

            //タイマー開始
            var wait = 10; // 消え始めるまでのウエイト
            _timer = NSTimer.CreateRepeatingScheduledTimer(TimeSpan.FromMilliseconds(70), delegate
            {
                // alpha値が0になったらViewのサイズを0にしてタイマーを停止する
                if (_view.Alpha <= 0)
                {
                    _timer.Invalidate();
                    _view.RemoveFromSuperview(); // 親ビューから削除する
                }
                else
                {
                    if (wait > 0)
                    {
                        wait--;
                    }
                    else
                    {
                        _view.Alpha -= (nfloat)0.05;
                    }
                }
            });
        }
    }
}
