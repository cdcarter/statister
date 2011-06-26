function(doc) {
	if(doc.type=="game" && doc.teamAtuh && doc.teamBtuh){
		// results =  [gp,wins,losses,pts,ptsa,ppg,pct,mrg,tens,negs,tuh,ppth,bhrd,bpts,ppb]
		var resultA = [1,0,0,doc.teamAscore,doc.teamBscore,0,0,0,0,0,doc.teamAtuh,0,doc.teamAbhrd,doc.teamAbpts,0];
		var resultB = [1,0,0,doc.teamBscore,doc.teamAscore,0,0,0,0,0,doc.teamBtuh,0,doc.teamBbhrd,doc.teamBbpts,0];
		
		if (doc.teamAscore > doc.teamBscore) {
			resultA[1] = 1
			resultB[2] = 1
		} else {
			resultA[2] = 1
			resultB[1] = 1
		}
		
		var _lenA = doc.teamAstats.length;
		for(var i=0;i< _lenA; ++i) {
			resultA[8] += doc.teamAstats[i].tens
			resultA[9] += doc.teamAstats[i].negs
		}
		
		var _lenB = doc.teamBstats.length;
		for(var i=0;i < _lenB; ++i) {
			resultB[8] += doc.teamBstats[i].tens
			resultB[9] += doc.teamBstats[i].negs
		}
		
		emit([doc.bracket,doc.teamA],resultA)
		emit([doc.bracket,doc.teamB],resultB)
	}
}