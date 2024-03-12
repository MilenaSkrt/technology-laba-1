class ArrayList
{

    int[] buffer = null; // массив для хранения элементов списка
	int count = 0; // количество элементов в списке

	void Expand()  // Метод расширения массива
	{
        if (count == 0) { this.buffer = new int[1]; } // если список пуст, создаем массив с одним элементом
		else
        {
            if (count == this.buffer.Length)
            {
                int[] buffer = new int[this.buffer.Length * 2];   // создаем новый массив в два раза больший и копируем элементы

				for (int i = 0; i < count; i++) { buffer[i] = this.buffer[i]; }

                this.buffer = buffer;
            }
        }
    }

    void Compression() // Метод сжатия массива
	{
        if (count <= buffer.Length / 2)
        {
            int[] buffer = new int[this.buffer.Length / 2]; // создаем новый массив в два раза меньший и копируем элементы

			for (int i = 0; i < count; i++) { buffer[i] = this.buffer[i]; }

            this.buffer = buffer;
        }
    }

    public void Add(int value) // Метод добавления элемента в конец списка
	{
        Expand(); // расширяем массив при необходимости
		buffer[count++] = value; // добавляем элемент в конец и увеличиваем счетчик
	}

    public void Insert(int value, int position)  // Метод вставки элемента по указанной позиции
	{
        if (position < count && position >= 0)
        {
            Expand();// расширяем массив
					 // сдвигаем элементы вправо и вставляем новый элемент на указанную позицию

			for (int i = count - 1; i >= position; i--)
            { buffer[i + 1] = buffer[i]; }

            buffer[position] = value;
            count++;

        }
        else
        {
            Add(value); // если позиция некорректная, добавляем элемент в конец
		}
    }

    public void Clean() // Метод очистки списка
	{
        buffer = null;
        count = 0;
    }

    public void Delete(int position) // Метод удаления элемента по указанной позиции
	{
        if (count == 1 && position == 0) { Clean(); } // если в списке остался один элемент, очищаем список
		else
        {
            if (position < count && position >= 0)
            {
                for (int i = position; i < count - 1; i++) { buffer[i] = buffer[i + 1]; } // сдвигаем элементы влево и уменьшаем счетчик

				buffer[count-- - 1] = 0;

                Compression(); // сжимаем массив при необходимости
			}
        }
    }

    public int Count // Свойство для получения количества элементов в списке
	{
        get { return count; }
    }

    public int this[int position] // Индексатор для доступа к элементам списка
	{
        get
        {
            if (position >= count || position < 0)
                return 0;
            else
                return buffer[position];
        }

        set
        {
            if (position < count && position >= 0) { buffer[position] = value; }
        }
    }

    public void Print()  // Метод для вывода списка на экран
	{
        Console.Write("[");
        for (int i = 0; i < count; i++)
        {

            if (i == count - 1) { Console.Write(buffer[i]); }
            else { Console.Write($"{buffer[i]}, "); }

        }
        Console.WriteLine("]");
    }


    }
