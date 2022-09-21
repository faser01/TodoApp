using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    internal class TodoModel:INotifyPropertyChanged
    {
        public DateTime CreationDate { get; private set; }= DateTime.Now;

		private bool _isDone;
		private string _text;

		

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnProperyChanged(string propertyName = "")
		{
			PropertyChanged?.Invoke (this, new PropertyChangedEventArgs(propertyName));
			
		}

		public bool IsDone
        {
			get { return  _isDone; }
			set
			{
				if (_isDone == value)
					return;
				_isDone = value;
				OnProperyChanged("IsDone");
			}
		}
		public  string Text
		{
			get { return _text ; }
			set 
			{
				if (_text == value)
					return;
				_text = value;
				OnProperyChanged("Text");
			}
		}
		



	}
}
