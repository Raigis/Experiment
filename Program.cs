// Это попытка создать простой консольный рогалик
void Start () {
    string answer;
    Console.Write($"Добро пожаловать!\nЕсли готовы начать, введите 'Y'.\nЕсли желаете выйти, нажмите 'N'.\n[Y/N]\n");
    while(true){
        answer = Console.ReadLine();
        if(answer.ToLower() != "y" && answer.ToLower() != "n") {
            Console.Write($"Неизвестный ввод.\nВведите 'Y' или 'N'.\n[Y/N]\n");
        } else break;
    }
    if (answer.ToLower() == "y"){
        Console.WriteLine($"Мы начинаем!");
        Console.WriteLine($"Заглушка");
    } else {
        Console.WriteLine($"До свидания!");
    }
}

Start();