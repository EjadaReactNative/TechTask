# Technical Task

1. Installation.
   For installing the project pull the code in the local machine
2. Run the project in Visual Studio
   After running the project the Web API will be listening on certain port

3. You can test the api's by the using the end points

    API 1
   POST : /api/user/register
   JSON Body
   {
     "fullName": "Ahmed",
     "phoneNumber": "0987654321",
     "email": "ahmed@example.com"
   }



    API 2
   POST: /api/auth/initiate-login
   JSON Body
   {
  "phoneNumber": "0987654321"
   }

   API 3
   POST: /api/auth/verify-otp
   JSON Body
   {
  "phoneNumber": "0987654321",
  "otp": "Use the OTP recieved"  //

  }

  4. To test the swagger use the following link
     http://localhost:{PortNumber}/swagger/index.html
