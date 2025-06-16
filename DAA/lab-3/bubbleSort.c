#include<stdio.h>
#include<time.h>

#define N 100

int readArrayFromFile(const char *filename, int arr[], int n){
    FILE *f = fopen(filename, 'r');

    if(!f){
        printf("can't open file");
        return 0;
    }

    for(int i = 0; i<n; i++){
        fscanf(f, "%d", &arr[i]);
    }
    fclose(f);
    return 1;
}

void main(){
    int arr[N];
    clock_t start, end;
    double time_taken;
    start = clock();
    //bubble
    end = clock();

    time_taken = ((double)(end-start))/CLOCKS_PER_SEC * 1000;
}