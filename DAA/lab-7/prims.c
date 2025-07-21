#include <stdio.h>
#include <limits.h>

#define v 5

void main(){
    int graph[v][v] = { { 0, 2, 0, 6, 0 },
                        { 2, 0, 3, 8, 5 },
                        { 0, 3, 0, 0, 7 },
                        { 6, 8, 0, 0, 9 },
                        { 0, 5, 7, 9, 0 } };
    
    int selected[v] = {0};
    selected[0] = 1;
    int edge = 0;

    int i,j;

    while(edge<v-1){
        int min = INT_MAX;
        int x,y = 0;

        for(i = 0; i<v; i++){
            if(selected[i]){
                for(j = 0; j<v; j++){
                    if(!selected[j] && graph[i][j]){
                        if(graph[i][j] < min){
                            min = graph[i][j];
                            x = i;
                            y = j;
                        }
                    }
                }
            }
        }
        selected[y] = 1;
        edge++;
    }
}