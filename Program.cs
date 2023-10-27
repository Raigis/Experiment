using System.Collections;
int CountRoom (ref int count) {
    count++;
    return count;
}

void Changer (ref int changeHP, ref int changeDEF, ref int changeATK, int chHP = 0, int chDEF = 0, int chATK = 0) {
    changeHP+=chHP;
    changeDEF+=chDEF;
    changeATK+=chATK;
}

int Status (ref int changeHP, ref int changeDEF, ref int changeATK, string parametr) {
    int hp = 100;
    int def = 0;
    int atk = 5;
    switch (parametr){
        case "HPFR": return hp;
        case "HP": return hp + changeHP;
        case "DEFFR": return def;
        case "DEF": return def + changeDEF;
        case "ATKFR": return atk;
        case "ATK": return atk + changeATK;
        default: return -1;
    }
}

void Event (ref int changeHP, ref int changeDEF, ref int changeATK) {
    Console.Clear();
    int random = new Random().Next(1, 5);
    switch(random){
    case 1:
    Changer(ref changeHP, ref changeDEF, ref changeATK, chHP : 1);
    Console.WriteLine($"Вы нашли зелье здоровья.\nHP+1\nНажмите любую клавишу, чтобы продолжить.");
    break;
    case 2: 
    Changer(ref changeHP, ref changeDEF, ref changeATK, chDEF : 1);
    Console.WriteLine($"Вы нашли часть брони.\nDEF+1\nНажмите любую клавишу, чтобы продолжить.");
    break;
    case 3: 
    Changer(ref changeHP, ref changeDEF, ref changeATK, chATK : 1);
    Console.WriteLine($"Вы нашли зелье атаки.\nATK+1\nНажмите любую клавишу, чтобы продолжить.");
    break;
    default:
    Console.WriteLine($"Вы ничего не нашли.\nНажмите любую клавишу, чтобы продолжить.");
    break;
    } 
}

void Switcher (string answer, ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    if (answer.ToLower() != "exit") {
        Event(ref changeHP, ref changeDEF, ref changeATK);
        Console.ReadKey();
    }
    switch(answer){
    case "1": 
    FrontRoom(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case "2": 
    LeftRoom(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case "3": 
    RightRoom(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case "4": 
    BackRoom(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    default:
    Console.WriteLine($"До свидания!");
    break;
    } 
}

void BackRoom1 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom (ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|*|  |");
    Console.WriteLine($"<____|  |");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
    Console.WriteLine($"4)-");
    Console.WriteLine($"\n[2/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '2' или 'EXIT'.\n[2/EXIT]\n");
        } else if (answer == "1") {
            Console.Write($"Назад идти нельзя.\nВведите '2' или 'EXIT'.\n[2/EXIT]\n");
        } else if (answer == "3" || answer == "4") {
            Console.Write($"Там стена.\nВведите '2' или 'EXIT'.\n[2/EXIT]\n");
        } else break;
    }
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void BackRoom2 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|*|  |");
    Console.WriteLine($"<__  |  |");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
    Console.WriteLine($"4)v");
    Console.WriteLine($"\n[2/4/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '2', '4' или 'EXIT'.\n[2/4/EXIT]\n");
        } else if (answer == "1") {
            Console.Write($"Назад идти нельзя.\nВведите '2', '4' или 'EXIT'.\n[2/4/EXIT]\n");
        } else if (answer == "3") {
            Console.Write($"Там стена.\nВведите '2', '4' или 'EXIT'.\n[2/4/EXIT]\n");
        } else break;
    }
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void BackRoom3 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"<__   __>");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)>\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
    Console.WriteLine($"4)v");
    Console.WriteLine($"\n[2/3/4/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '2', '3', '4' или 'EXIT'.\n[2/3/4/EXIT]\n");
        } else if (answer == "1") {
            Console.Write($"Назад идти нельзя.\nВведите '2', '3', '4' или 'EXIT'.\n[2/3/4/EXIT]\n");
        } else break;
    }
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void BackRoom4 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|  |*|__|");
    Console.WriteLine($"|  |  __>");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)>\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
    Console.WriteLine($"4)v");
    Console.WriteLine($"\n[3/4/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '3', '4' или 'EXIT'.\n[3/4/EXIT]\n");
        } else if (answer == "1") {
            Console.Write($"Назад идти нельзя.\nВведите '3', '4' или 'EXIT'.\n[3/4/EXIT]\n");
        } else if (answer == "2") {
            Console.Write($"Там стена.\nВведите '3', '4' или 'EXIT'.\n[3/4/EXIT]\n");
        } else break;
    }
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void BackRoom5 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|  |*|__|");
    Console.WriteLine($"|  |____>");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)>\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
    Console.WriteLine($"4)-");
    Console.WriteLine($"\n[3/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '3' или 'EXIT'.\n[3/EXIT]\n");
        } else if (answer == "1") {
            Console.Write($"Назад идти нельзя.\nВведите '3' или 'EXIT'.\n[3/EXIT]\n");
        } else if (answer == "4" || answer == "2") {
            Console.Write($"Там стена.\nВведите '3' или 'EXIT'.\n[3/EXIT]\n");
        } else break;
    }
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void BackRoom6 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"<_______>");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)>\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
    Console.WriteLine($"4)-");
    Console.WriteLine($"\n[2/3/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '2', '3' или 'EXIT'.\n[2/3/EXIT]\n");
        } else if (answer == "1") {
            Console.Write($"Назад идти нельзя.\nВведите '2', '3' или 'EXIT'.\n[2/3/EXIT]\n");
        } else if (answer == "4") {
            Console.Write($"Там стена.\nВведите '2', '3' или 'EXIT'.\n[2/3/EXIT]\n");
        } else break;
    }
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void BackRoom7 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|  |*|  |");
    Console.WriteLine($"|  | |  |");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
    Console.WriteLine($"4)v");
    Console.WriteLine($"\n[4/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '4' или 'EXIT'.\n[4/2/EXIT]\n");
        } else if (answer == "1") {
            Console.Write($"Назад идти нельзя.\nВведите '4' или 'EXIT'.\n[4/2/EXIT]\n");
        } else if (answer == "2" || answer == "3") {
            Console.Write($"Там стена.\nВведите '4' или 'EXIT'.\n[4/2/EXIT]\n");
        } else break;
    }
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void BackRoom (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    int random = new Random().Next(1, 8);
    switch(random){
    case 1: 
    BackRoom1(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case 2: 
    BackRoom2(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case 3: 
    BackRoom3(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case 4: 
    BackRoom4(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case 5: 
    BackRoom5(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case 6: 
    BackRoom6(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    default:
    BackRoom7(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    } 
}

void RightRoom1 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" _______");
    Console.WriteLine($"|____   |");
    Console.WriteLine($"*__  |  |");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
    Console.WriteLine($"4)v");
    Console.WriteLine($"\n[4/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '4' или 'EXIT'.\n[4/EXIT]\n");
        } else if (answer == "2") {
            Console.Write($"Назад идти нельзя.\nВведите '4' или 'EXIT'.\n[4/EXIT]\n");
        } else if (answer == "1" || answer == "3") {
            Console.Write($"Там стена.\nВведите '4' или 'EXIT'.\n[4/EXIT]\n");
        } else break;
    }
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void RightRoom2 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" _______");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"*__   __>");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)>\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
    Console.WriteLine($"4)v");
    Console.WriteLine($"\n[3/4/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '3', '4' или 'EXIT'.\n[3/4/EXIT]\n");
        } else if (answer == "2") {
            Console.Write($"Назад идти нельзя.\nВведите '3', '4' или 'EXIT'.\n[3/4/EXIT]\n");
        } else if (answer == "1") {
            Console.Write($"Там стена.\nВведите '3', '4' или 'EXIT'.\n[3/4/EXIT]\n");
        } else break;
    }
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void RightRoom3 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|^|__|");
    Console.WriteLine($"*__   __>");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)>\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
    Console.WriteLine($"4)v");
    Console.WriteLine($"\n[1/3/4/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '1', '3', '4' или 'EXIT'.\n[1/3/4/EXIT]\n");
        } else if (answer == "2") {
            Console.Write($"Назад идти нельзя.\nВведите '1', '3', '4' или 'EXIT'.\n[1/3/4/EXIT]\n");
        } else break;
    }
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void RightRoom4 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|^|__|");
    Console.WriteLine($"*_______>");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)>\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
    Console.WriteLine($"4)-");
    Console.WriteLine($"\n[1/3/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '1', '3' или 'EXIT'.\n[1/3/EXIT]\n");
        } else if (answer == "2") {
            Console.Write($"Назад идти нельзя.\nВведите '1', '3' или 'EXIT'.\n[1/3/EXIT]\n");
        } else if (answer == "4") {
            Console.Write($"Там стена.\nВведите '1', '3' или 'EXIT'.\n[1/3/EXIT]\n");
        } else break;
    }
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void RightRoom5 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|^|  |");
    Console.WriteLine($"*____|  |");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
    Console.WriteLine($"4)-");
    Console.WriteLine($"\n[1/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '1' или 'EXIT'.\n[1/EXIT]\n");
        } else if (answer == "2") {
            Console.Write($"Назад идти нельзя.\nВведите '1' или 'EXIT'.\n[1/EXIT]\n");
        } else if (answer == "3" || answer == "4") {
            Console.Write($"Там стена.\nВведите '1' или 'EXIT'.\n[1/EXIT]\n");
        } else break;
    }
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void RightRoom6 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|^|  |");
    Console.WriteLine($"*__  |  |");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
    Console.WriteLine($"4)v");
    Console.WriteLine($"\n[1/4/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '1', '4' или 'EXIT'.\n[1/4/EXIT]\n");
        } else if (answer == "2") {
            Console.Write($"Назад идти нельзя.\nВведите '1', '4' или 'EXIT'.\n[1/4/EXIT]\n");
        } else if (answer == "3") {
            Console.Write($"Там стена.\nВведите '1', '4' или 'EXIT'.\n[1/4/EXIT]\n");
        } else break;
    }
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void RightRoom7 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" _______");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"*_______>");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)>\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
    Console.WriteLine($"4)-");
    Console.WriteLine($"\n[3/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '3' или 'EXIT'.\n[3/EXIT]\n");
        } else if (answer == "2") {
            Console.Write($"Назад идти нельзя.\nВведите '3' или 'EXIT'.\n[3/EXIT]\n");
        } else if (answer == "1" || answer == "4") {
            Console.Write($"Там стена.\nВведите '3' или 'EXIT'.\n[3/EXIT]\n");
        } else break;
    }
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void RightRoom (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    int random = new Random().Next(1, 8);
    switch(random){
    case 1: 
    RightRoom1(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case 2: 
    RightRoom2(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case 3: 
    RightRoom3(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case 4: 
    RightRoom4(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case 5: 
    RightRoom5(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case 6: 
    RightRoom6(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    default:
    RightRoom7(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    } 
}

void LeftRoom1 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" _______");
    Console.WriteLine($"|   ____|");
    Console.WriteLine($"|  |  __*");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
    Console.WriteLine($"4)v");
    Console.WriteLine($"\n[4/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '4' или 'EXIT'.\n[4/EXIT]\n");
        } else if (answer == "3") {
            Console.Write($"Назад идти нельзя.\nВведите '4' или 'EXIT'.\n[4/EXIT]\n");
        } else if (answer == "1" || answer == "2") {
            Console.Write($"Там стена.\nВведите '4' или 'EXIT'.\n[4/EXIT]\n");
        } else break;
    }
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void LeftRoom2 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" _______");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"<__   __*");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
    Console.WriteLine($"4)v");
    Console.WriteLine($"\n[2/4/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '2', '4' или 'EXIT'.\n[2/4/EXIT]\n");
        } else if (answer == "3") {
            Console.Write($"Назад идти нельзя.\nВведите '2', '4' или 'EXIT'.\n[2/4/EXIT]\n");
        } else if (answer == "1") {
            Console.Write($"Там стена.\nВведите '2', '4' или 'EXIT'.\n[2/4/EXIT]\n");
        } else break;
    }
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void LeftRoom3 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|^|__|");
    Console.WriteLine($"<__   __*");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
    Console.WriteLine($"4)v");
    Console.WriteLine($"\n[1/2/4/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '1', '2', '4' или 'EXIT'.\n[1/2/4/EXIT]\n");
        } else if (answer == "3") {
            Console.Write($"Назад идти нельзя.\nВведите '1', '2', '4' или 'EXIT'.\n[1/2/4/EXIT]\n");
        } else break;
    }
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void LeftRoom4 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|^|__|");
    Console.WriteLine($"<_______*");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
    Console.WriteLine($"4)-");
    Console.WriteLine($"\n[1/2/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '1', '2' или 'EXIT'.\n[1/2/EXIT]\n");
        } else if (answer == "3") {
            Console.Write($"Назад идти нельзя.\nВведите '1', '2' или 'EXIT'.\n[1/2/EXIT]\n");
        } else if (answer == "4") {
            Console.Write($"Там стена.\nВведите '1', '2' или 'EXIT'.\n[1/2/EXIT]\n");
        } else break;
    }
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void LeftRoom5 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|  |^|__|");
    Console.WriteLine($"|  |____*");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
    Console.WriteLine($"4)-");
    Console.WriteLine($"\n[1/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '1' или 'EXIT'.\n[1/EXIT]\n");
        } else if (answer == "3") {
            Console.Write($"Назад идти нельзя.\nВведите '1' или 'EXIT'.\n[1/EXIT]\n");
        } else if (answer == "4" || answer == "2") {
            Console.Write($"Там стена.\nВведите '1' или 'EXIT'.\n[1/EXIT]\n");
        } else break;
    }
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void LeftRoom6 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|  |^|__|");
    Console.WriteLine($"|  |  __*");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
    Console.WriteLine($"4)v");
    Console.WriteLine($"\n[1/4/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '1', '4' или 'EXIT'.\n[1/4/EXIT]\n");
        } else if (answer == "3") {
            Console.Write($"Назад идти нельзя.\nВведите '1', '4' или 'EXIT'.\n[1/4/EXIT]\n");
        } else if (answer == "2") {
            Console.Write($"Там стена.\nВведите '1', '4' или 'EXIT'.\n[1/4/EXIT]\n");
        } else break;
    }
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void LeftRoom7 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" _______");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"<_______*");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
    Console.WriteLine($"4)-");
    Console.WriteLine($"\n[2/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '2' или 'EXIT'.\n[2/EXIT]\n");
        } else if (answer == "3") {
            Console.Write($"Назад идти нельзя.\nВведите '2' или 'EXIT'.\n[2/EXIT]\n");
        } else if (answer == "1" || answer == "4") {
            Console.Write($"Там стена.\nВведите '2' или 'EXIT'.\n[2/EXIT]\n");
        } else break;
    }
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void LeftRoom (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    int random = new Random().Next(1, 8);
    switch(random){
    case 1: 
    LeftRoom1(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case 2: 
    LeftRoom2(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case 3: 
    LeftRoom3(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case 4: 
    LeftRoom4(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case 5: 
    LeftRoom5(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case 6: 
    LeftRoom6(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    default:
    LeftRoom7(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    } 
}

void FrontRoom1 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" _______");
    Console.WriteLine($"|____   |");
    Console.WriteLine($"<__  |  |");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
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
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void FrontRoom2 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|^|  |");
    Console.WriteLine($"<__  |  |");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
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
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void FrontRoom3 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|^|__|");
    Console.WriteLine($"<__   __>");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)>\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
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
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void FrontRoom4 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|  |^|__|");
    Console.WriteLine($"|  |  __>");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)>\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
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
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void FrontRoom5 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" _______");
    Console.WriteLine($"|   ____|");
    Console.WriteLine($"|  |  __>");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)>\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
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
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void FrontRoom6 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" _______");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"<__   __>");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)>\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
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
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void FrontRoom7 (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|  |^|  |");
    Console.WriteLine($"|  | |  |");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEF")}");
    Console.WriteLine($"3)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATK")}");
    Console.WriteLine($"4)-");
    Console.WriteLine($"\n[1/EXIT]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer != "3" && answer != "4" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '1' или 'EXIT'.\n[1/2/EXIT]\n");
        } else if (answer == "4") {
            Console.Write($"Назад идти нельзя.\nВведите '1' или 'EXIT'.\n[1/2/EXIT]\n");
        } else if (answer == "2" || answer == "3") {
            Console.Write($"Там стена.\nВведите '1' или 'EXIT'.\n[1/2/EXIT]\n");
        } else break;
    }
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void FrontRoom (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    int random = new Random().Next(1, 8);
    switch(random){
    case 1: 
    FrontRoom1(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case 2: 
    FrontRoom2(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case 3: 
    FrontRoom3(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case 4: 
    FrontRoom4(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case 5: 
    FrontRoom5(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    case 6: 
    FrontRoom6(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    default:
    FrontRoom7(ref count, ref changeHP, ref changeDEF, ref changeATK);
    break;
    } 
}

void FirstRoom (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Мы начинаем!");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|^|__|");
    Console.WriteLine($"<__   __>");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"\nЭто первая комната.\nСтрелками обозначены пути, куда ты можешь пойти.\nЗвёздочка же указывает на твоё место положение.\nДля выбора направления введи число, соответствующее нужной стрелке в списке внизу.\nТакже, левее списка выбора можно увидеть свои характеристики.\nЕсли желаете выйти, введите 'EXIT'.\n");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeDEF, ref changeATK, "HPFR")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tDEF:{Status(ref changeHP, ref changeDEF, ref changeATK, "DEFFR")}");
    Console.WriteLine($"3)>\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeDEF, ref changeATK, "ATKFR")}");
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
    Switcher(answer, ref count, ref changeHP, ref changeDEF, ref changeATK);
}

void Start (ref int count, ref int changeHP, ref int changeDEF, ref int changeATK) {
    string answer;
    Console.Write($"Добро пожаловать!\nЕсли готовы начать, введите 'Y'.\nЕсли желаете выйти, нажмите 'N'.\n[Y/N]\n");
    while(true){
        answer = Console.ReadLine();
        if(answer.ToLower() != "y" && answer.ToLower() != "n") {
            Console.Write($"Неизвестный ввод.\nВведите 'Y' или 'N'.\n[Y/N]\n");
        } else break;
    }
    if (answer.ToLower() == "y"){
        FirstRoom(ref count, ref changeHP, ref changeDEF, ref changeATK);
    } else {
        Console.WriteLine($"До свидания!");
    }
}

int count = 0;
int changeHP = 0;
int changeDEF = 0;
int changeATK = 0;
Start(ref count, ref changeHP, ref changeDEF, ref changeATK);
