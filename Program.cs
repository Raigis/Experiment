// Это попытка создать простой консольный рогалик
using System.Collections;
void Switcher (string answer){
    switch(answer){
    case "1": 
    Console.WriteLine($"Заглушка");
    break;
    case "2": 
    Console.WriteLine($"Заглушка");
    break;
    case "3": 
    Console.WriteLine($"Заглушка");
    break;
    case "4": 
    Console.WriteLine($"Заглушка");
    break;
    default:
    Console.WriteLine($"До свидания!");
    break;
    } 
}

void FirstRoom () {
    string answer;
    Console.Clear();
    Console.WriteLine($"Мы начинаем!");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|^|__|");
    Console.WriteLine($"<__   __>");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"\nЭто первая комната.\nСтрелками обозначены пути, куда ты можешь пойти.\nЗвёздочка же указывает на твоё место положение.\nДля выбора направления введи число, соответствующее нужной стрелке в списке внизу.\nТакже, левее списка выбора можно увидеть свои характеристики.\nЕсли желаете выйти, введите 'EXIT'.\n");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:100");
    Console.WriteLine($"2)<\t\t\t\t\t\tDEF:100");
    Console.WriteLine($"3)>\t\t\t\t\t\tATK:5");
    Console.WriteLine($"\n[1/2/3/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '1', '2', '3' или 'EXIT'.\n[1/2/3/EXIT]\n");
        } else break;
    }
    Switcher(answer);
}

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
        FirstRoom();
    } else {
        Console.WriteLine($"До свидания!");
    }
}

Start();