/* eslint-disable import/prefer-default-export */
import enumRoles from '../enums/enumRoles';

const auth = ({ next, store }) => {
  const isLoggedIn = store.state.token !== null && store.state.token.length > 0;
  if (!isLoggedIn) {
    return next({
      name: 'login',
    });
  }
  if (Object.keys(store.state.loggedUser).length === 0) {
    store.dispatch('GetUser');
  }
  return next();
};

const admin = ({ next, store }) => {
  const isAdmin = store.state.loggedUser.roleId === enumRoles.Administrator;
  if (!isAdmin) {
    return next({
      name: 'login',
    });
  }
  return next();
};

const operator = ({ next, store }) => {
  const isOperator = store.state.loggedUser.roleId === enumRoles.Operator;
  if (!isOperator) {
    return next({
      name: 'login',
    });
  }
  return next();
};

export { auth, admin, operator };
