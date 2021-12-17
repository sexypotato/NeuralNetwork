using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISLab3
{
	public class Neuron // Класс нейрона
	{
		public Neuron(double[] _inputs, double[] _weights, NeuronType _type) //Конструктор формального нейрона
		{
			Inputs = _inputs; 
			Weights = _weights; 
			type = _type; 
		}
		public NeuronType type; //Тип нейрона
		public double[] Inputs { get; set; } //Вектор входных сигналов
		public double[] Weights { get; set; } //Вектор весов входных сигналов нейрона (синапсов) 
	//	public double[] LastError { get; set; } //Вектор ошибок. Не нужен ПОТОМ СТЕРЕТЬ 
		public double Output; //Результат
		public double Derivative { get; set; } //Производная
		private double a = 0.0001d; //Допустимое значение ошибки
		
	public void Activator(double[] inputs, double[] weights) //Сигмоидная функция активации
		{
			double sum = 0;
			for(int i = 0; i < inputs.Length; ++i)
			{
				//линейные преобразования 
				sum += inputs[i] * weights[i+1];
			}
			switch (type)
			{
				case NeuronType.Hidden://для нейронов скрытого слоя
					Output = LeakyReLU(sum);
					Derivative = LeakyReLU_Derivativator(sum);
					break;
				case NeuronType.Output://для нейронов выходного слоя
					Output = Math.Exp(sum);
					break;
			}

		}
		private double LeakyReLU(double sum) => (sum >= 0) ? sum : a * sum;

		private double LeakyReLU_Derivativator(double sum) => (sum >= 0) ? 1 : a;
	}
}
