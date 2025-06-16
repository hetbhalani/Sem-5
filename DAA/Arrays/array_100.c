#include<stdio.h>
#include<stdlib.h>
#include<time.h>

#define N 100000

void best_case(){
    FILE *f = fopen("best_case_100000.txt", "w");

    for(int i = 0; i<N; i++){
        fprintf(f, "%d ", i);
    }
    fclose(f);
}

void worst_case(){
    FILE *f = fopen("worst_case_100000.txt", "w");

    for(int i = N; i>0; i--){
        fprintf(f, "%d ", i);
    }
    fclose(f);
}

void average_case(){
    int a[N];

    for(int i = 0; i<N; i++){
        a[i] = i+1;
    }

    srand(9);
    for(int i = N-1; i>=0; i--){
        int j = rand() % (i+1);
        int temp = a[i];
        a[i] = a[j];
        a[j] = temp;
    }

    FILE *f = fopen("avg_case_100000.txt", "w");

    for(int i = 0; i<N; i++){
        fprintf(f, "%d ", a[i]);
    }
    fclose(f);
}

void main(){
    best_case();
    worst_case();
    average_case();
}