import axios, { AxiosResponse } from 'axios';
import IUserSignUpDto from '../types/IUserSignUpDto';
import IUserSignInDto from '../types/IUserSignInDto';

export default class UsersService {
    public signUp(user: IUserSignUpDto): Promise<AxiosResponse<any, any>> {
        console.log(user);
        const response = axios.post(
            'http://localhost:5129/api/Users/SignUp',
            user,
        );
        console.log(response);

        return response;
    }

    public signIn(user: IUserSignInDto): void {
        console.log(user);

        const response = axios.post(
            'http://localhost:5129/api/Users/SignIn',
            user,
        );

        console.log(response);
    }
}
