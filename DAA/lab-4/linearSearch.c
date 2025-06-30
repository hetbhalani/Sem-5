#include<stdio.h>
#include<time.h>

void linear_search(int a[], int n, int x){
    int i, flag = 0;
    for(i = 0; i<n; i++){
        if(a[i] == x){
            printf("Element is found at index {%d}",i);
            flag = 1;
            break;
            
        }
    }
    if(flag == 0) printf("No element is found!!!");
    
}

void main(){
    int i=0;
    FILE* file;
    clock_t start,end;
    double cpu_time_used;
    int n = 100000;
    int arr[n];

    //best case
    file = fopen("../Arrays/best_case_100000.txt","r");
    for(i=0;i<n;i++){
        fscanf(file,"%d",&arr[i]);
    }
    fclose(file);

    printf("Enter element to search: ");
    int x;
    scanf("%d", &x);

    start = clock();
    linear_search(arr,n,x);
    end = clock();
    cpu_time_used = ((double)(end - start)/CLOCKS_PER_SEC);
    printf("\nTime taken to Search element in Array Using linear search is : %f",cpu_time_used);
}