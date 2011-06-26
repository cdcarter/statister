(doc) ->
	if (doc.type=="game") 
		for player in doc.teamAstats
			emit [doc.teamA,player.name],null
			
		for player in doc.teamBstats
			emit [doc.teamB,player.name],null 