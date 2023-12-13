variable "vpc_id" {
  type = string
  //fake
  default = "vpc-01e6258d771394cd2"
}
variable "private_subnets" {
  type = list(any)
  //fake
  default = [
      "subnet-0645832d707a8f267",
      "subnet-02febd33a9c97ac4f"
  ]
}