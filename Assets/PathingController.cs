using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathingController
{
    static PathingController instance;
    double [,,,] dist;
    GridCoord [,,,] next;
    int [,] weights;
    int num_vertices;
    int num_vertices_x;
    int num_vertices_y;
    int normalizer;
    public static PathingController get_instance()
    {
        if(instance == null)
        {
            instance = new PathingController();
        }
        return instance;
    }
    // Start is called before the first frame update
    public void call_me_first(int[,] materials, int x, int y){
        Debug.Log("I was called first!");
        num_vertices_x = x;
        num_vertices_y = y;
        num_vertices = x*y;
        weights = materials;
        dist = new double[x,y,x,y];
        next = new GridCoord [x,y,x,y];
        Debug.Log(new Vector2(x,y));
        // For each source-destination vertex pair, initialize:
        for(int i=0;i<x;i++){
            for(int j=0;j<y;j++){
                for(int k=0;k<x;k++){
                    for(int l=0;l<y;l++){
                        dist[i,j,k,l]=double.PositiveInfinity;
                    }
                }
            }
        }
        // Don't consider edges
        for(int i=0; i<x-1; i++){ // Can always consider East
            for(int j=0; j<y-1; j++){ // Can always consider South
                // [i+1,j]
                dist[i,j,i+1,j] = 1;
                // [j+1,j+1]
                dist[i,j,i+1,j+1] = 1;
                // [i,j+1]
                dist[i,j,i,j+1] = 1;
                if(i>0){
                    // [i-1,j+1]
                    dist[i,j,i-1,j+1] = 1;
                }
                // [i,j] SELF
                dist[i,j,i,j] = 1;
            }
        }
        // // Intermediate vertices
        // for(int a=0;a<x;a++){
        //     for(int b=0;b<y;b++){
        //         // Immediate source-Dest pairs by weight
        //         for(int i=0;i<x;i++){
        //             for(int j=0;j<y;j++){
        //                 for(int k=0;k<x;k++){
        //                     for(int l=0;l<y;l++){
        //                         double alt = dist[i,j,a,b] + dist[a,b,k,l];
        //                         if(alt < dist[i,j,k,l]){
        //                             dist[i,j,k,l] = alt;
        //                             next[i,j] = 1;
        //                         }
        //                     }
        //                 }
        //             }
        //         }
        //     }
        // }
        
    }
    public void recompute_minimums()
    {
        Debug.Log("I was asked to recompute.");
        int x = num_vertices_x;
        int y = num_vertices_y;
        for(int a=0;a<x;a++){
            for(int b=0;b<y;b++){
                // Immediate source-Dest pairs by weight
                for(int i=0;i<x;i++){
                    for(int j=0;j<y;j++){
                        for(int k=0;k<x;k++){
                            for(int l=0;l<y;l++){
                                double alt = dist[i,j,a,b] + dist[a,b,k,l];
                                if(alt < dist[i,j,k,l]){
                                    dist[i,j,k,l] = alt;
                                    next[i,j,k,l] = new GridCoord(k,l,alt);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    public int[] query_graph(int pos_x, int pos_y, int goal_x, int goal_y)
    {
        int i=pos_x,j=pos_y,k=goal_x,l=goal_y;
        GridCoord v = next[i,j,k,l];

        Debug.Log("I was queried.");
        Debug.Log(next[i,j,k,l]);
        
        int[] val = new int[] {v.x,v.y};
        return val;
    }
    private int f_neighborhood(int x, int y)
    {
        for(int i=0; i<x-1; i++){ // Can always consider East
            for(int j=0; j<y-1; j++){ // Can always consider South
                // [i+1,j]
                // [j+1,j+1]
                // [i,j+1]
                if(i>0){
                    // [i-1,j+1]
                }
                // [i,j] SELF
            }
        }
        return 0;
    }
}

public struct GridCoord
{
    public int x,y;
    public double dist;
    public GridCoord(int p1, int p2, double d)
    {
        x=p1;
        y=p2;
        dist=d;
    }
}