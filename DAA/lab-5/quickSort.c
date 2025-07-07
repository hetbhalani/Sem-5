#include<stdio.h>

int quick(int a[], int low, int high){
    if(low < high){
        int p = partition(a,low,high);
        quick(a,low,p-1);
        quick(a,p+1,high);
    }
}

int partition(int a[], int low, int high){
    int p = a[low];
    int k = low;
    int l = high+1;

    k++;
    while(k<high && a[k]>=p){
        k++;
    }

    l--;
    while(l>low && a[l]<p){
        l--;
    }

    while(l<k){
        int temp = a[l];
        a[l] = a[k];
        a[k] = temp;

        k++;
        while(k<high && a[k]>=p){
            k++;
        }

        l--;
        while(l>low && a[l]<p){
            l--;
        }
    }

    int temp = p;
    p = a[l];
    a[l] = temp;

    return low;
}


int showArray(int a[], int n){
    for(int i = 0;i<n; i++){
        printf("%d", a[i]);
    }
}

void main(){
    int a[] = {3,1,4,1,5,9,2,6,5,3,5,8,9};
    int n = sizeof(a) / sizeof(a[0]);

    quick(a,0,n+1);
    showArray(a,n);
}