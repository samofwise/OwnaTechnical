# Owna Technical Test
![badge](https://github.com/samofwise/OwnaTechnical/actions/workflows/actions.yml/badge.svg)
  
## Deployment details
The project is deployed to AWS Elastic Beanstalk using Github Actions.\
You can view the hosted project here: [http://ownatest-dev.eba-frsxu3fm.ap-southeast-2.elasticbeanstalk.com/swagger](http://ownatest-dev.eba-frsxu3fm.ap-southeast-2.elasticbeanstalk.com/swagger)

## Decisions
I attempted to implement CQRS architecture and DDD to the best of my ability. As we did not talk about CQRS architecture in the interview or is it mentioned on my resume, I assume you knew that I do not have experience in CQRS architecture however I gave it my best shot in 2 hours.\
I would need to research the CQRS architecture pattern to see if I correctly implemented it.

There are a few things I would like to have done in the program if I had more time:

- Change OrderStatus to convert to a string for the Application Layer to make it more user friendly
- With this change include error handling for if a user assigns a OrderStatus that is not valid (Bad Request)
- Include Error handling for if a user attempts to update a record that doesn't exist (Returning a NotFound Result)

One other descision I made was to create the Order Id manually in the Infrastructure Layer. This would not be needed if I was using a relational database service such as MongoDb Atlas as they generate Id keys automatically.
