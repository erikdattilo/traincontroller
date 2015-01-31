// // Copyright (c) 2004-2010 Sergey Lyubka
// //
// // Permission is hereby granted, free of charge, to any person obtaining a copy
// // of this software and associated documentation files (the "Software"), to deal
// // in the Software without restriction, including without limitation the rights
// // to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// // copies of the Software, and to permit persons to whom the Software is
// // furnished to do so, subject to the following conditions:
// //
// // The above copyright notice and this permission notice shall be included in
// // all copies or substantial portions of the Software.
// //
// // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// // IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// // FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// // AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// // LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// // OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// // THE SOFTWARE.
// 
// #ifndef MONGOOSE_HEADER_INCLUDED
// #define  MONGOOSE_HEADER_INCLUDED
// 
// #ifdef __cplusplus
// extern "C" {
// #endif // __cplusplus
// 
// struct mg_context;     // Handle for the HTTP service itself
// struct mg_connection;  // Handle for the individual connection
// 
// 
// // This structure contains information about the HTTP request.
// struct mg_request_info {
//   void *user_data;       // User-defined pointer passed to mg_start()
//   string request_method;  // "GET", "POST", etc
//   string uri;             // URL-decoded URI
//   string http_version;    // E.g. "1.0", "1.1"
//   string query_string;    // 0 - terminated
//   string remote_user;     // Authenticated user
//   string log_message;     // Mongoose error log message
//   long remote_ip;        // Client's IP address
//   int remote_port;       // Client's port
//   int status_code;       // HTTP reply status code
//   int is_ssl;            // 1 if SSL-ed, 0 if not
//   int num_headers;       // Number of headers
//   struct mg_header {
//     string name;          // HTTP header name
//     string value;         // HTTP header value
//   } http_headers[64];    // Maximum 64 headers
// };
// 
// // Various events on which user-defined function is called by Mongoose.
// enum mg_event {
//   MG_NEW_REQUEST,   // New HTTP request has arrived from the client
//   MG_HTTP_ERROR,    // HTTP error must be returned to the client
//   MG_EVENT_LOG,     // Mongoose logs an event, request_info.log_message
//   MG_INIT_SSL       // Mongoose initializes SSL. Instead of mg_connection *,
//                     // SSL context is passed to the callback function.
// };
// 
// // Prototype for the user-defined function. Mongoose calls this function
// // on every event mentioned above.
// //
// // Parameters:
// //   event: which event has been triggered.
// //   conn: opaque connection handler. Could be used to read, write data to the
// //         client, etc. See functions below that accept "mg_connection *".
// //   request_info: Information about HTTP request.
// //
// // Return:
// //   If handler returns non-null, that means that handler has processed the
// //   request by sending appropriate HTTP reply to the client. Mongoose treats
// //   the request as served.
// //   If callback returns null, that means that callback has not processed
// //   the request. Handler must not send any data to the client in this case.
// //   Mongoose proceeds with request handling as if nothing happened.
// typedef void * (*mg_callback_t)(enum mg_event event,
//                                 struct mg_connection *conn,
//                                 const struct mg_request_info *request_info);
// 
// 
// // Start web server.
// //
// // Parameters:
// //   callback: user defined event handling function or null.
// //   options: null terminated list of option_name, option_value pairs that
// //            specify Mongoose configuration parameters.
// //
// // Example:
// //   string options[] = {
// //     "document_root", "/var/www",
// //     "listening_ports", "80,443s",
// //     null
// //   };
// //   struct mg_context *ctx = mg_start(&my_func, null, options);
// //
// // Please refer to http://code.google.com/p/mongoose/wiki/MongooseManual
// // for the list of valid option and their possible values.
// //
// // Return:
// //   web server context, or null on error.
// struct mg_context *mg_start(mg_callback_t callback, void *user_data,
//                             string options);
// 
// 
// // Stop the web server.
// //
// // Must be called last, when an application wants to stop the web server and
// // release all associated resources. This function blocks until all Mongoose
// // threads are stopped. Context pointer becomes invalid.
// void mg_stop(struct mg_context *);
// 
// 
// // Get the value of particular configuration parameter.
// // The value returned is read-only. Mongoose does not allow changing
// // configuration at run time.
// // If given parameter name is not valid, null is returned. For valid
// // names, return value is guaranteed to be non-null. If parameter is not
// // set, zero-length string is returned.
// string name);
// 
// 
// // Return array of strings that represent valid configuration options.
// // For each option, a short name, long name, and default value is returned.
// // Array is null terminated.
// string mg_get_valid_option_names(void);
// 
// 
// // Add, edit or delete the entry in the passwords file.
// //
// // This function allows an application to manipulate .htpasswd files on the
// // fly by adding, deleting and changing user records. This is one of the
// // several ways of implementing authentication on the server side. For another,
// // cookie-based way please refer to the examples/chat.c in the source tree.
// //
// // If password is not null, entry is added (or modified if already exists).
// // If password is null, entry is deleted.
// //
// // Return:
// //   1 on success, 0 on error.
// int mg_modify_passwords_file(string passwords_file_name,
//                              string domain,
//                              string user,
//                              string password);
// 
// // Send data to the client.
// int mg_write(struct mg_connection *, const void *buf, size_t len);
// 
// 
// // Send data to the browser using printf() semantics.
// //
// // Works exactly like mg_write(), but allows to do message formatting.
// // Note that mg_printf() uses internal buffer of size IO_BUF_SIZE
// // (8 Kb by default) as temporary message storage for formatting. Do not
// // print data that is bigger than that, otherwise it will be truncated.
// int mg_printf(struct mg_connection *, string fmt, ...);
// 
// 
// // Read data from the remote end, return number of bytes read.
// int mg_read(struct mg_connection *, void *buf, size_t len);
// 
// 
// // Get the value of particular HTTP header.
// //
// // This is a helper function. It traverses request_info.http_headers array,
// // and if the header is present in the array, returns its value. If it is
// // not present, null is returned.
// string name);
// 
// 
// // Get a value of particular form variable.
// //
// // Parameters:
// //   data: pointer to form-uri-encoded buffer. This could be either POST data,
// //         or request_info.query_string.
// //   data_len: length of the encoded data.
// //   var_name: variable name to decode from the buffer
// //   buf: destination buffer for the decoded variable
// //   buf_len: length of the destination buffer
// //
// // Return:
// //   On success, length of the decoded variable.
// //   On error, -1 (variable not found, or destination buffer is too small).
// //
// // Destination buffer is guaranteed to be '0' - terminated. In case of
// // failure, dst[0] == '0'.
// int mg_get_var(string data, size_t data_len,
//     string buf, size_t buf_len);
// 
// // Fetch value of certain cookie variable into the destination buffer.
// //
// // Destination buffer is guaranteed to be '0' - terminated. In case of
// // failure, dst[0] == '0'. Note that RFC allows many occurrences of the same
// // parameter. This function returns only first occurrence.
// //
// // Return:
// //   On success, value length.
// //   On error, -1 (either "Cookie:" header is not present at all, or the
// //   requested parameter is not found, or destination buffer is too small
// //   to hold the value).
// int mg_get_cookie(const struct mg_connection *,
//     string buf, size_t buf_len);
// 
// 
// // Return Mongoose version.
// string mg_version(void);
// 
// 
// // MD5 hash given strings.
// // Buffer 'buf' must be 33 bytes long. Varargs is a null terminated list of
// // asciiz strings. When function returns, buf will contain human-readable
// // MD5 hash. Example:
// //   char buf[33];
// //   mg_md5(buf, "aa", "bb", null);
// void mg_md5(string buf, ...);
// 
// 
// #ifdef __cplusplus
// }
// #endif // __cplusplus
// 
// #endif // MONGOOSE_HEADER_INCLUDED
