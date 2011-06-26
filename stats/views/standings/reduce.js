function(keys,values,rereduce) {
	// results =  [gp,wins,losses,pts,ptsa,ppg,pct,mrg,tens,negs,tuh,ppth,bhrd,bpts,ppb]
	var results = [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0];
	
	var _lenV = values.length;
	for (var i=0; i < _lenV; ++i) {
		var _len = values[i].length;
		for(var s=0; s < _len; ++s) {
			results[s] += values[i][s]
		}
	}
	
	//ppg
	results[5] = results[3] / results[0]
	
	//pct
	results[6] = results[1] / results[0]
	
	//mrg
	results[7] = (results[3] - results[4]) / results[0]
	
	//ppth
	results[11] = results[3] / results[10]
	
	//ppb
	results[14] = results[13] / results[12]
	
	return results
}