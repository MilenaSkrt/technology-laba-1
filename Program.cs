using System.Collections;

internal class Program
{
    // Основной метод, который будет вызван при запуске программы
    static void Main(string[] args)
    {
        {
            ArrayList array = new ArrayList(); // Создаем новый экземпляр ArrayList и ChainList
            ChainList chain = new ChainList();

            Random rnd = new Random(); // Создаем новый генератор случайных чисел
            for (int i = 0; i < 10; i++) // Цикл для выполнения случайных операций
            {
                int operation = rnd.Next(4); // Генерируем случайное число для выбора операции
                int item = rnd.Next(10); // Генерируем случайное число для элемента
                int pos = rnd.Next(10);  // Генерируем случайное число для позиции
                switch (operation)
                {
                    case 1: // Добавляем элемент в оба списка
                        array.Add(item);  
                        chain.Add(item);
                        break;
                    case 2: // Удаляем элемент на указанной позиции из обоих списков
                        array.Delete(pos);  
                        chain.Delete(pos);
                        break;
                    case 3:  // Вставляем элемент на указанную позицию в оба списка
                        array.Insert(pos, item);
                        chain.Insert(pos, item);
                        break;
                    case 4: // Очищаем оба списка
                        array.Clean();
                        chain.Clean();
                        break;
                }
            }
            // Выводим содержимое обоих списков
            array.Print();
            Console.WriteLine();
            chain.Print();

         
        }
    }
}
