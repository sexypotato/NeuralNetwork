using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISLab3
{
	public enum NeuronType //Тип слоя, в котором находится нейрон
	{
		Hidden,
		Output
	}
	public enum NetworkMode // Сетевой режим
	{
		Train, // Обучение
		Test,
		Demo
	}
	public enum MemoryMode //Режим памяти
	{
		GET,
		SET
	}
}
