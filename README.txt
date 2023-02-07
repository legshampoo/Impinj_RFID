# RFID Reader and Event server
Written in C#

Detects read events from an [Impinj RFID Device](https://www.impinj.com/products/readers)
And uses websockets to send the RFID data to a Node server and Crestron server
which then provides the data to update a dashboard UI built with React

Part of a site-specific, interactive media installation to detect when certain objects were placed (which had RFID tags attached to the bottom)


