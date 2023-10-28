//Это простенький консольный рогалик. Введи dotnet run и играй.
using System.Collections;
int CountRoom (ref int count) {
    count++;
    return count;
}

void Changer (ref int count, ref int changeHP, ref int changeATK, ref int changePoison, int chHP = 0, int chATK = 0, int chPoison = 0) {
    changeHP+=chHP;
    changeATK+=chATK;
    changePoison+=chPoison;
    if (chHP == 0 && chATK == 0 && chPoison == 0){
        if (changePoison>0){
            changeHP-=2;
            changePoison--;
        }
    }
    if (changeHP<=-100){
         GameOver(ref count, ref changeHP, ref changeATK, ref changePoison);
    }
}

int Status (ref int changeHP, ref int changeATK, string parametr) {
    int hp = 100;
    int atk = 5;
    switch (parametr){
        case "HPFR": return hp;
        case "HP": return hp + changeHP;
        case "ATKFR": return atk;
        case "ATK": return atk + changeATK;
        default: return -1;
    }
}

int EnemyStatus (ref int count, string parametr) {
    int hp = 10 + new Random().Next(count);
    int atk = 3 + new Random().Next(count/2);
    switch (parametr){
        case "HP": return hp;
        case "ATK": return atk;
        default: return -1;
    }
}

void GameOver(ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    Console.Clear();
    Console.WriteLine($"Вы проиграли.\nНажмите любую клавишу, чтобы выйти");
    Console.ReadKey();
    Console.WriteLine($"До свидания!");
    Environment.Exit(0);
}

void Victory() {
    Console.Clear();
    Console.WriteLine($"Вы победили.\nНажмите любую клавишу, чтобы продолжить.");
}

void Battle (ref int count, ref int changeHP, ref int changeATK, ref int changePoison, ref int enemyHP, ref int enemyATK) {
    int myHP = Status(ref changeHP, ref changeATK, "HP");
    int myATK = Status(ref changeHP, ref changeATK, "ATK");
    while (true) {
        enemyHP -= myATK;
        myHP -= enemyATK;
        Changer(ref count, ref changeHP, ref changeATK, ref changePoison, chHP: -enemyATK);
        if (enemyHP <= 0) {
            Victory();
            break;
        }
    }
    
}

void Evade (ref int count, ref int changeHP, ref int changeATK, ref int changePoison, ref int enemyHP, ref int enemyATK) {
    Console.Clear(); 
    int evadeChance = 10;
    for (int i = evadeChance; i >= 8; i--){
        if (i == 8) {
            Console.WriteLine($"Сбежать больше не получится.\nПридётся биться.\nНажмите любую клавишу, чтобы продолжить.");
            Console.ReadKey();
            Battle(ref count, ref changeHP, ref changeATK, ref changePoison, ref enemyHP, ref enemyATK);
            break;
        }
        int random = new Random().Next(i);
        if (random <5) {
            string answer;
            Console.WriteLine($"Сбежать не получилось.\nПопробовать снова?");
            Console.WriteLine($"1) Биться");
            Console.WriteLine($"2) Бежать");
            Console.WriteLine($"\n[1/2/EXIT]");
            while(true){
                answer = Console.ReadLine();
                if(answer != "1" && answer != "2" && answer.ToLower() != "exit") {
                    Console.Write($"Неизвестный ввод.\nВведите '1' или '2'.\n[1/2/EXIT]\n");
                } else if (answer == "1") {
                    Battle(ref count, ref changeHP, ref changeATK, ref changePoison, ref enemyHP, ref enemyATK);
                    break;
                } else if (answer == "2"){
                    break;
                } else {
                    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
                    break;
                }
            }
        } else {
            Console.WriteLine($"Вы смогли сбежать.\nНажмите любую клавишу, чтобы продолжить.");
            break;
        }
    }
} 

void Enemy (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    int enemyHP = EnemyStatus(ref count, "HP");
    int enemyATK = EnemyStatus(ref count, "ATK");
    Console.Clear();
    Console.WriteLine($"[ ]\t\t\t\tHP:{enemyHP}");
    Console.WriteLine($"/|\\\t\t\t\tATK:{enemyATK}");
    Console.WriteLine($"/ \\");
    Console.WriteLine($"Вам преградили путь.\nБудете биться или постараетесь бежать?");
    Console.WriteLine($"1) Биться");
    Console.WriteLine($"2) Бежать");
    Console.WriteLine($"\n[1/2]");
    while(true){
        answer = Console.ReadLine();
        if(answer != "1" && answer != "2" && answer.ToLower() != "exit") {
            Console.Write($"Неизвестный ввод.\nВведите '1' или '2'.\n[1/2]\n");
        } else if (answer == "1") {
            Battle(ref count, ref changeHP, ref changeATK, ref changePoison, ref enemyHP, ref enemyATK);
            break;
        } else {
            Evade(ref count, ref changeHP, ref changeATK, ref changePoison, ref enemyHP, ref enemyATK);
            break;
        }
    }

}

void Poison(ref int count, ref int changeHP, ref int changeATK, ref int changePoison){
    Console.Clear();
    int chPoison = new Random().Next(1, 6);
    Console.WriteLine($"Вы угодили в ядовитую ловувшку.\nВ течение {chPoison} ходов HP-2\nНажмите любую клавишу, чтобы продолжить.");
    Changer(ref count, ref changeHP, ref changeATK, ref changePoison, chPoison : chPoison);
}

void Event (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    Console.Clear();
    int random = new Random().Next(1, 6);
    switch(random){
    case 1:
    Changer(ref count, ref changeHP, ref changeATK, ref changePoison, chHP : 1);
    Console.WriteLine($"Вы нашли зелье здоровья.\nHP+1\nНажмите любую клавишу, чтобы продолжить.");
    break;
    case 2: 
    Changer(ref count, ref changeHP, ref changeATK, ref changePoison, chATK : 1);
    Console.WriteLine($"Вы нашли зелье атаки.\nATK+1\nНажмите любую клавишу, чтобы продолжить.");
    break;
    case 3:
    Enemy(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case 4:
    Poison(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    default:
    Console.WriteLine($"Вы ничего не нашли.\nНажмите любую клавишу, чтобы продолжить.");
    break;
    } 
}

void Switcher (string answer, ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    Changer(ref count, ref changeHP, ref changeATK, ref changePoison);
    if (answer.ToLower() != "exit") {
        Event(ref count, ref changeHP, ref changeATK, ref changePoison);
        Console.ReadKey();
    }
    switch(answer){
    case "1": 
    FrontRoom(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case "2": 
    LeftRoom(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case "3": 
    RightRoom(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case "4": 
    BackRoom(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    default:
    Console.WriteLine($"До свидания!");
    Environment.Exit(0);
    break;
    } 
}

void BackRoom1 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom (ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|*|  |");
    Console.WriteLine($"<____|  |");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)-");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void BackRoom2 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|*|  |");
    Console.WriteLine($"<__  |  |");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)-");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void BackRoom3 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"<__   __>");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)>");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void BackRoom4 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|  |*|__|");
    Console.WriteLine($"|  |  __>");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)>");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void BackRoom5 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|  |*|__|");
    Console.WriteLine($"|  |____>");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)>");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void BackRoom6 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"<_______>");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)>");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void BackRoom7 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|  |*|  |");
    Console.WriteLine($"|  | |  |");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)-");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void BackRoom (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    int random = new Random().Next(1, 8);
    switch(random){
    case 1: 
    BackRoom1(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case 2: 
    BackRoom2(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case 3: 
    BackRoom3(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case 4: 
    BackRoom4(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case 5: 
    BackRoom5(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case 6: 
    BackRoom6(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    default:
    BackRoom7(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    } 
}

void RightRoom1 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" _______");
    Console.WriteLine($"|____   |");
    Console.WriteLine($"*__  |  |");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)-");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void RightRoom2 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" _______");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"*__   __>");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)>");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void RightRoom3 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|^|__|");
    Console.WriteLine($"*__   __>");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)>");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void RightRoom4 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|^|__|");
    Console.WriteLine($"*_______>");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)>");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void RightRoom5 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|^|  |");
    Console.WriteLine($"*____|  |");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)-");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void RightRoom6 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|^|  |");
    Console.WriteLine($"*__  |  |");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)-");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void RightRoom7 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" _______");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"*_______>");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)>");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void RightRoom (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    int random = new Random().Next(1, 8);
    switch(random){
    case 1: 
    RightRoom1(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case 2: 
    RightRoom2(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case 3: 
    RightRoom3(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case 4: 
    RightRoom4(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case 5: 
    RightRoom5(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case 6: 
    RightRoom6(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    default:
    RightRoom7(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    } 
}

void LeftRoom1 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" _______");
    Console.WriteLine($"|   ____|");
    Console.WriteLine($"|  |  __*");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)-");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void LeftRoom2 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" _______");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"<__   __*");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)-");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void LeftRoom3 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|^|__|");
    Console.WriteLine($"<__   __*");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)-");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void LeftRoom4 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|^|__|");
    Console.WriteLine($"<_______*");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)-");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void LeftRoom5 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|  |^|__|");
    Console.WriteLine($"|  |____*");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)-");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void LeftRoom6 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|  |^|__|");
    Console.WriteLine($"|  |  __*");
    Console.WriteLine($"|__|v|__|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)-");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void LeftRoom7 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" _______");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"<_______*");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)-");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void LeftRoom (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    int random = new Random().Next(1, 8);
    switch(random){
    case 1: 
    LeftRoom1(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case 2: 
    LeftRoom2(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case 3: 
    LeftRoom3(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case 4: 
    LeftRoom4(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case 5: 
    LeftRoom5(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case 6: 
    LeftRoom6(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    default:
    LeftRoom7(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    } 
}

void FrontRoom1 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" _______");
    Console.WriteLine($"|____   |");
    Console.WriteLine($"<__  |  |");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)-");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void FrontRoom2 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|^|  |");
    Console.WriteLine($"<__  |  |");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)-");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void FrontRoom3 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|^|__|");
    Console.WriteLine($"<__   __>");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)>");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void FrontRoom4 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|  |^|__|");
    Console.WriteLine($"|  |  __>");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)>");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void FrontRoom5 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" _______");
    Console.WriteLine($"|   ____|");
    Console.WriteLine($"|  |  __>");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)>");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void FrontRoom6 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" _______");
    Console.WriteLine($"|_______|");
    Console.WriteLine($"<__   __>");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"1)-\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)>");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void FrontRoom7 (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Ход: {CountRoom(ref count)}");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|  |^|  |");
    Console.WriteLine($"|  | |  |");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HP")}");
    Console.WriteLine($"2)-\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATK")}");
    Console.WriteLine($"3)-");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void FrontRoom (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    int random = new Random().Next(1, 8);
    switch(random){
    case 1: 
    FrontRoom1(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case 2: 
    FrontRoom2(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case 3: 
    FrontRoom3(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case 4: 
    FrontRoom4(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case 5: 
    FrontRoom5(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    case 6: 
    FrontRoom6(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    default:
    FrontRoom7(ref count, ref changeHP, ref changeATK, ref changePoison);
    break;
    } 
}

void FirstRoom (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    string answer;
    Console.Clear();
    Console.WriteLine($"Мы начинаем!");
    Console.WriteLine($" __   __");
    Console.WriteLine($"|__|^|__|");
    Console.WriteLine($"<__   __>");
    Console.WriteLine($"|__|*|__|");
    Console.WriteLine($"\nЭто первая комната.\nСтрелками обозначены пути, куда ты можешь пойти.\nЗвёздочка же указывает на твоё место положение.\nДля выбора направления введи число, соответствующее нужной стрелке в списке внизу.\nТакже, левее списка выбора можно увидеть свои характеристики.\nЕсли желаете выйти, введите 'EXIT'.\n");
    Console.WriteLine($"1)^\t\t\t\t\t\tHP:{Status(ref changeHP, ref changeATK, "HPFR")}");
    Console.WriteLine($"2)<\t\t\t\t\t\tATK:{Status(ref changeHP, ref changeATK, "ATKFR")}");
    Console.WriteLine($"3)>");
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
    Switcher(answer, ref count, ref changeHP, ref changeATK, ref changePoison);
}

void Start (ref int count, ref int changeHP, ref int changeATK, ref int changePoison) {
    Console.Clear();
    string answer;
    Console.Write($"Добро пожаловать!\nЕсли готовы начать, введите 'Y'.\nЕсли желаете выйти, нажмите 'N'.\n[Y/N]\n");
    while(true){
        answer = Console.ReadLine();
        if(answer.ToLower() != "y" && answer.ToLower() != "n") {
            Console.Write($"Неизвестный ввод.\nВведите 'Y' или 'N'.\n[Y/N]\n");
        } else break;
    }
    if (answer.ToLower() == "y"){
        FirstRoom(ref count, ref changeHP, ref changeATK, ref changePoison);
    } else {
        Console.WriteLine($"До свидания!");
    }
}

int count = 0;
int changeHP = 0;
int changeATK = 0;
int changePoison = 0;
Start(ref count, ref changeHP, ref changeATK, ref changePoison);