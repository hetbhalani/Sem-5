#include<stdio.h>

void merge(int a[], int l, int mid, int r){
    int p1 = mid - l + 1;
    int p2 = r - mid;

    int leftA [p1];
    int rightA [p2];

    for(int i = 0; i<p1; i++){
        leftA[i] = a[l+i];
    }
    for(int j = 0; j<p2; j++){
        rightA[j] = a[mid+1+j];
    }

    int i = 0, j = 0, k = l;

    while(i<p1 && j<p2){
        if(leftA[i]<=rightA[j]){
            a[k] = leftA[i++];
        }
        else{
            a[k] = rightA[j++];
        }
        k++;
    }
    while(i < p1){
        a[k] = leftA[i];
        i++;
        k++;
    }

    while(j < p2){
        a[k] = rightA[j];
        j++;
        k++;
    }
}

void partition(int a[],int l, int r){
    if(l<r){
        int mid = l+(r-l)/2;

        partition(a, l, mid);
        partition(a, mid + 1, r);

        merge(a, l, mid, r);
    }
}


void main(){
    int a [] = {1,4,6,2,4,7,3,9,6,5};
    int size = sizeof(a) / sizeof(a[0]);

    partition(a, 0, size - 1);

    for(int i = 0; i < size; i++){
        printf("%d ", a[i]);
    }
}