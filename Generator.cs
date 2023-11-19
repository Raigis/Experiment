public static class Generator{
    private static int[] ArrayAppend (int[] array, int temp){
        int[] result = new int[array.Length+1];
        array.CopyTo(result, 0);
        result[array.Length] = temp;
        return result;
    }
    private static int[] VarX(int x){
        if(x == 1 || x ==4 || x ==5 || x == 7 || x == 8 || x == 9 || x == 11 || x == 14 || x == 18 || x == 22){
            int[] poss = {1,2,3,6,7,9,11,12,16,20};
            return poss;
        } else {
            int[] poss = {4,5,8,10,13,14,15,17,18,19,21,22,23};
            return poss;
        }
    }
    private static int UpperEdge(bool enter, bool exit, int x){
        int cell;
        int[] poss1 = VarX(x);
        if (!enter && !exit){
            int[] poss2 = {2,5,9,11,16,18,19,20,22,23};
            int[] possibles = new int[1];
            for (int i = 0; i < poss1.Length; i++){
                for (int j = 0; j < poss2.Length; j++){
                    if (poss1[i] == poss2[j]) {
                        if (possibles[0] == 0) possibles[0] = j;
                        possibles = ArrayAppend(possibles, poss2[j]);
                    }
                }
            }
            cell = possibles[new Random().Next(0, possibles.Length)];
        } else if (!enter){
            int[] poss2 = {2,5,9,11,20,22,23};
            int[] possibles = new int[1];
            for (int i = 0; i < poss1.Length; i++){
                for (int j = 0; j < poss2.Length; j++){
                    if (poss1[i] == poss2[j]) {
                        if (possibles[0] == 0) possibles[0] = j;
                        possibles = ArrayAppend(possibles, poss2[j]);
                    }
                }
            }
            cell = possibles[new Random().Next(0, possibles.Length)];
        } else if (!exit){
            int[] poss2 = {2,5,9,11,12,14,15,16,18,19};
            int[] possibles = new int[1];
            for (int i = 0; i < poss1.Length; i++){
                for (int j = 0; j < poss2.Length; j++){
                    if (poss1[i] == poss2[j]) {
                        if (possibles[0] == 0) possibles[0] = j;
                        possibles = ArrayAppend(possibles, poss2[j]);
                    }
                }
            }
            cell = possibles[new Random().Next(0, possibles.Length)];
        } else {
            int[] poss2 = {2,5,9,11,12,14,15};
            int[] possibles = new int[1];
            for (int i = 0; i < poss1.Length; i++){
                for (int j = 0; j < poss2.Length; j++){
                    if (poss1[i] == poss2[j]) {
                        if (possibles[0] == 0) possibles[0] = poss2[j];
                        possibles = ArrayAppend(possibles, poss2[j]);
                    }
                }
            }
            cell = possibles[new Random().Next(0, possibles.Length)];
        }
        return cell;
    }
    private static int LeftUpperCorner(bool enter, bool exit){
        int cell;
        if (!enter && !exit){
            int[] possibles = {5,18,19,22,23};
            cell = possibles[new Random().Next(0, possibles.Length)];
        } else if (!enter){
            int[] possibles = {5,22,23};
            cell = possibles[new Random().Next(0, possibles.Length)];
        } else if (!exit){
            int[] possibles = {5,14,15,18,19};
            cell = possibles[new Random().Next(0, possibles.Length)];
        } else {
            int[] possibles = {5,14,15};
            cell = possibles[new Random().Next(0, possibles.Length)];
        }
        return cell;
    }
    public static int[,] MapGenerating(){
        bool isEnter = false;
        bool isExit = false;
        int[,] map = new int[new Random().Next(5,11),new Random().Next(5,11)];
        for(int i = 0; i < map.GetLength(0); i++ ){
            for(int j = 0; j < map.GetLength(1); j++){
                if (i == 0 && j == 0) map[i,j] = LeftUpperCorner(isEnter, isExit);
                else if (i == 0 && j != map.GetLength(1)-1) map[i,j] = UpperEdge(isEnter, isExit, map[i, j-1]);
                if(map [i,j] == 16 || map [i,j] == 17 || map [i,j] == 18 || map [i,j] == 19) isExit = true;
                if(map [i,j] == 20 || map [i,j] == 21 || map [i,j] == 22 || map [i,j] == 23) isEnter = true;
            }
        }
        return map;
    }
}