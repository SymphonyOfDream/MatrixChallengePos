# MatrixChallengePos
DEBUG database setup with employee ID/passwords of
1 / aaa, 2 / bbb, 3 / ccc, and 4 / ddd

Currently uses SQLite for the data store, but that is abstracted away, and an easy change with NINJECT can help adapt to other backends.

The DB schema is significantly more complex than the application--I got carried away, now half of the DB is not used the way it should be.

On startup, click the Start Purchase Transaction button.
In the Transaction panel that appears, you can search for products, then add them to the transaction.
Each line item of the transaction can be deleted, or have its quantity increased or decreased.

Click the Pay button to complete the transaction and "pay" (cash only this iteration!).
Click the Cancel Transaction button to just cancel out of the transaction.
