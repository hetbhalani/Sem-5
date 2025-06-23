#include<stdio.h>
#include<time.h>

// 64. WAP to implement insertion sort algorithm.

#include <stdio.h>

void insertionSort(int arr[], int size) {

    for (int i = 1; i < size; i++) {
        int key = arr[i];  
        int j = i - 1;

        while (j >= 0 && arr[j] > key) {
            arr[j + 1] = arr[j];
            j = j - 1;
        }

        arr[j + 1] = key;
    }
}

void main() {
    int i=0;
    FILE* file;
    clock_t start,end;
    double cpu_time_used;
    int n = 100000;
    int arr[n];

    //worst case
    file = fopen("./Arrays/best_case_100000.txt","r");
    for(i=0;i<n;i++){
        fscanf(file,"%d",&arr[i]);
    }
    fclose(file);

    start = clock();
    insertionSort(arr,n);
    end = clock();
    cpu_time_used = ((double)(end - start)/CLOCKS_PER_SEC);
    printf("Time taken to Sot Array Using Bubble Sort in Worst Case is : %f",cpu_time_used);

}