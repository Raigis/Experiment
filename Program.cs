using System.Collections;
int CountRoom(int counter = 0){
    int count;
    if (counter == 0) {
        count = 0;
    } else count = 0 + counter;
    return count;
}

int Changer(string parametr, int chHP = 0, int chDEF = 0, int chATK = 0){
    int changeHP;
    int changeDEF;
    int changeATK;
    if (CountRoom() == 0) {
        changeHP = chHP;
        changeDEF = chDEF;
        changeATK = chATK;
    } else {
        changeHP = 0 + chHP;
        changeDEF = 0 + chDEF;
        changeATK = 0 + chATK;
    }
    switch (parametr){
        case "HP": return changeHP;
        case "DEF": return changeDEF;
        case "ATK": return changeATK;
        default: return -1;
    }
}

int Status (string parametr) {
    int hp = 100;
    int def = 0;
    int atk = 5;
    switch (parametr){
        case "HPFR": return hp;
        case "HP": return hp + Changer(parametr);
        case "DEFFR": return def;
        case "DEF": return def + Changer(parametr);
        case "ATKFR": return atk;
        case "ATK": return atk + Changer(parametr);
        default: return -1;
    }
}

void Switcher (string answer){
    switch(answer){
    case "1": 
    FrontRoom();
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

void FrontRoom1 () {
    string answer;
    Console.Clear();
    Console.WriteLine($" _______");
    Console.WriteLine($"|____   |");
    Console.WriteLine($"<__  |  |");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status("HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tDEF:{Status("DEF")}");
    Console.WriteLine($"3)-\t\t\t\t\t\tATK:{Status("ATK")}");
    Console.WriteLine($"4)-");
    Console.WriteLine($"\n[2/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '2' или 'EXIT'.\n[2/EXIT]\n");
        } else if (answer == "4") {
            Console.Write($"Назад идти нельзя.\nВведите '2' или 'EXIT'.\n[2/EXIT]\n");
        } else if (answer == "1" || answer == "3") {
            Console.Write($"Там стена.\nВведите '2' или 'EXIT'.\n[2/EXIT]\n");
        } else break;
    }
    Switcher(answer);
}

void FrontRoom2 () {
    string answer;
    Console.Clear();
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|^|  |");
    Console.WriteLine($"<__  |  |");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status("HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tDEF:{Status("DEF")}");
    Console.WriteLine($"3)-\t\t\t\t\t\tATK:{Status("ATK")}");
    Console.WriteLine($"4)-");
    Console.WriteLine($"\n[1/2/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '1', '2' или 'EXIT'.\n[1/2/EXIT]\n");
        } else if (answer == "4") {
            Console.Write($"Назад идти нельзя.\nВведите '1', '2' или 'EXIT'.\n[1/2/EXIT]\n");
        } else if (answer == "3") {
            Console.Write($"Там стена.\nВведите '1', '2' или 'EXIT'.\n[1/2/EXIT]\n");
        } else break;
    }
    Switcher(answer);
}

void FrontRoom3 () {
    string answer;
    Console.Clear();
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|^|__|");
    Console.WriteLine($"<__   __>");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status("HPFR")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tDEF:{Status("DEFFR")}");
    Console.WriteLine($"3)>\t\t\t\t\t\tATK:{Status("ATKFR")}");
    Console.WriteLine($"4)-");
    Console.WriteLine($"\n[1/2/3/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '1', '2', '3' или 'EXIT'.\n[1/2/3/EXIT]\n");
        } else if (answer == "4") {
            Console.Write($"Назад идти нельзя.\nВведите '1', '2', '3' или 'EXIT'.\n[1/2/3/EXIT]\n");
        } else break;
    }
    Switcher(answer);
}

void FrontRoom4 () {
    string answer;
    Console.Clear();
    Console.WriteLine($" __   __");
    Console.WriteLine($"|  |^|__|");
    Console.WriteLine($"|  |  __>");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status("HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tDEF:{Status("DEF")}");
    Console.WriteLine($"3)>\t\t\t\t\t\tATK:{Status("ATK")}");
    Console.WriteLine($"4)-");
    Console.WriteLine($"\n[1/3/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '1', '3' или 'EXIT'.\n[1/3/EXIT]\n");
        } else if (answer == "4") {
            Console.Write($"Назад идти нельзя.\nВведите '1', '3' или 'EXIT'.\n[1/3/EXIT]\n");
        } else if (answer == "2") {
            Console.Write($"Там стена.\nВведите '1', '3' или 'EXIT'.\n[1/3/EXIT]\n");
        } else break;
    }
    Switcher(answer);
}

void FrontRoom5 () {
    string answer;
    Console.Clear();
    Console.WriteLine($" _______");
    Console.WriteLine($"|   ____|");
    Console.WriteLine($"|  |  __>");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status("HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tDEF:{Status("DEF")}");
    Console.WriteLine($"3)>\t\t\t\t\t\tATK:{Status("ATK")}");
    Console.WriteLine($"4)-");
    Console.WriteLine($"\n[3/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '3' или 'EXIT'.\n[3/EXIT]\n");
        } else if (answer == "4") {
            Console.Write($"Назад идти нельзя.\nВведите '3' или 'EXIT'.\n[3/EXIT]\n");
        } else if (answer == "1" || answer == "2") {
            Console.Write($"Там стена.\nВведите '3' или 'EXIT'.\n[3/EXIT]\n");
        } else break;
    }
    Switcher(answer);
}

void FrontRoom6 () {
    string answer;
    Console.Clear();
    Console.WriteLine($" _______");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"<__   __>");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status("HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tDEF:{Status("DEF")}");
    Console.WriteLine($"3)>\t\t\t\t\t\tATK:{Status("ATK")}");
    Console.WriteLine($"4)-");
    Console.WriteLine($"\n[2/3/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '2', '3' или 'EXIT'.\n[2/3/EXIT]\n");
        } else if (answer == "4") {
            Console.Write($"Назад идти нельзя.\nВведите '2', '3' или 'EXIT'.\n[2/3/EXIT]\n");
        } else if (answer == "1") {
            Console.Write($"Там стена.\nВведите '2', '3' или 'EXIT'.\n[2/3/EXIT]\n");
        } else break;
    }
    Switcher(answer);
}

void FrontRoom (){
    int random = new Random().Next(1, 7);
    switch(random){
    case 1: 
    FrontRoom1();
    break;
    case 2: 
    FrontRoom2();
    break;
    case 3: 
    FrontRoom3();
    break;
    case 4: 
    FrontRoom4();
    break;
    case 5: 
    FrontRoom5();
    break;
    default:
    FrontRoom6();
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
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status("HPFR")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tDEF:{Status("DEFFR")}");
    Console.WriteLine($"3)>\t\t\t\t\t\tATK:{Status("ATKFR")}");
    Console.WriteLine($"4)-");
    Console.WriteLine($"\n[1/2/3/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '1', '2', '3' или 'EXIT'.\n[1/2/3/EXIT]\n");
        } else if (answer == "4") {
            Console.Write($"Назад идти нельзя.\nВведите '1', '2', '3' или 'EXIT'.\n[1/2/3/EXIT]\n");
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