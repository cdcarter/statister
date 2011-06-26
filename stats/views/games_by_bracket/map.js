function(doc) {
  if (doc.type=="game") {
    emit([doc.bracket,doc.round,doc.room], [doc.teamA,doc.teamB]);
  }
};