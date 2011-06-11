function(keys,values,rereduce) {
	if(!rereduce) {
           var wins =0;
           for(v in values) {
             if(values[v]) {wins+=1}
           }
           return [wins/values.length,wins,values.length]
        } else {
           var wins = 0;
           var games = 0;
           for (v in values){
             wins += values[v][1]
             games += values[v][2]
           }
           return [wins/games,wins,games]
        }
}