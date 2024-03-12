class ChainList
{
    public class Node // Внутренний класс для представления узла списка
	{
        public int Data { get; set; } // Данные в узле

		public Node Next { get; set; } // Ссылка на следующий узел

		public Node(int data, Node next) // Конструктор узла с заданными данными и ссылкой на следующий узел
		{
            Data = data;
            Next = next;

        }
    }
	// Ссылка на начало списка
	Node head = null;
    int count = 0; // Количество элементов в списке


	public Node Find(int position) // Метод для поиска узла по заданной позиции
	{
        if (position >= count || position < 0) { return null; } // Если позиция некорректна, вернуть null
		int i = 0;
        Node p = head;
        while (p != null && i < position) // Перебор узлов до заданной позиции
		{
            p = p.Next;
            i++;
        }

        if (i == position) { return p; } // Вернуть найденный узел
		else { return null; } // Вернуть null, если узел не найден

	}

    public void Add(int value) // Метод для добавления нового элемента в конец списка
	{
        if (head == null || count == 0) { head = new Node(value, null); } // Если список пуст, создать новый узел в начале
		else
        {

            Find(count - 1).Next = new Node(value, null); // Добавить новый узел в конец списка

		}
        count++; // Увеличить количество элементов в списке
	}

    public void Insert(int value, int position) // Метод для вставки нового элемента на заданную позицию
	{
        if (position < count && position > 0) // Если позиция валидна
		{

            Node OldNode = Find(position - 1);
            Node NewNode = new Node(value, OldNode.Next);
            OldNode.Next = NewNode; // Вставить новый узел на указанную позицию

		}
		else // Если позиция некорректна
		{

            if (position == 0) { head = new Node(value, head); } // Вставить новый узел в начало списка
			else { Add(value); count--; } // Добавить новый узел в конец списка

		}
        count++;// Увеличить количество элементов в списке
	}

    public void Clean() // Метод для очистки списка
	{

        head = null;// Удалить все узлы
		count = 0;// Обнулить количество элементов

	}

    public void Delete(int position) // Метод для удаления элемента на заданной позиции
	{

        if (count == 1 && position == 0) { Clean(); } // Если в списке только один элемент
		else
        {

            if (position < count && position >= 0) // Если позиция валидна
			{
                if (position == 0) { head = head.Next; } // Удалить первый узел

				else { Find(position - 1).Next = Find(position + 1); } // Удалить узел на заданной позиции

				count--; // Уменьшить количество элементов в списке
			}

        }
    }
        
    public int Count  // Свойство для получения количества элементов в списке
	{
        get { return count; } 
    }


    public void Print() // Метод для вывода элементов списка
	{
        Console.Write("[");
        Node p = head; // Устанавливаем указатель p на головной узел
		for (int i = 0; i < count; i++)  // Проходим по всем элементам списка
		{

            if (i == count - 1) { Console.Write(p.Data); } // Если текущий элемент - последний, выводим его значение без запятой
			else { Console.Write($"{p.Data}, "); } // Иначе выводим значение элемента с запятой и пробелом
			p = p.Next; // Переходим к следующему элементу

		}
        Console.WriteLine("]");
    }

        }
  
