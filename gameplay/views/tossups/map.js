function(doc) {
  if (doc.type=="tossup") {
    emit([doc.packet,doc.number], doc._id);
  }
};