function(keys, values, rereduce) {
    if (!rereduce){
        var tuhary =[];
        var ptsary =[];
        for (v in values) {
          tuhary.push(values[v][1])
          ptsary.push(values[v][0])
        }
        pts=sum(ptsary)
        tuh=sum(tuhary)
        return [pts/tuh,pts,tuh]
    }else{
        var tuhary =[];
        var ptsary =[];
        for(r in values) {
          tuhary.push(values[r][2])
          ptsary.push(values[r][1])
        }
        pts=sum(ptsary)
        tuh=sum(tuhary)
        return [pts/tuh,pts,tuh]
    }
}