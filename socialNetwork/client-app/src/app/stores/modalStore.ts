import { makeAutoObservable } from "mobx";
import {} from "semantic-ui-react";

interface Modal {
  open: boolean;
  body: JSX.Element | null;
}

export default class modalStore {
  modal: Modal = {
    open: false,
    body: null,
  };

  constructor() {
    makeAutoObservable(this);
  }

  openModal = (content: JSX.Element) => {
    this.modal.open = true;
    this.modal.body = content;
  };

  closeModal = () => {
    this.modal.open = false;
    this.modal.body = null;
  };
}
