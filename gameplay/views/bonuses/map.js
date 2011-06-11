function(doc) {
  if (doc.type=="bonus") {
    emit([doc.packet,doc.number], doc._id);
  }
};