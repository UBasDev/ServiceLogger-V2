# ServiceLogger
<h1>What are the functions of this API?</h1>
<p>ServiceLogger sends request to the specified endpoint and handles the response. According to the status of response:</p>
<p>1-ServiceLogger is creating a "RequestLog.txt" file[path is 'Documents' for every host] and logs into it</p>
<p>2-Logs to the SQLServer database</p>
<p>3-Sends emails to the specified mail accounts</p>
<p>4-Sends SMS to the specified users with Twilio services</p>
