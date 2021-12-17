using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISLab3
{
	class Presenter // Путеводная нить программы
	{
        private Network _net; // Конкретная сеть
        private Form1 _view; //Конкретная форма

        public Presenter(Network model, Form1 view) // Конструктор
        {
            _net = model; //Принимаем на вход сеть, которую создали в форме
            _view = view; //Сама форма
            _view.GotResult += new EventHandler<EventArgs>(OnGotResult); //Выдаём результат
        }

        private void OnGotResult(object sender, EventArgs e)
        {
            _net.ForwardPass(_net, _view.InputPixels); // Передвигаемся на слой вперёд(???)
            UpdateView(); 
        }

        private void UpdateView() => _view.NetOutput = _net.fact; //передаём выходной массив
    }
}
